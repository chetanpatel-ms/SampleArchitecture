using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SampleArchitecture.Api.Validation;
using SampleArchitecture.Commands;

namespace SampleArchitecture.Api.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="IServiceCollection" />.
    /// </summary>
    internal static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Decorates the <see cref="ICommandHandler{TCommand, TResult}"/> with the specified <see cref="IValidator{T}"/>.
        /// </summary>
        /// <typeparam name="TCommandHandler">The type of <see cref="ICommandHandler{TCommand, TResult}"/>.</typeparam>
        /// <typeparam name="TValidator">The type of <see cref="IValidator{T}"/>.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection"/>.</param>
        /// <returns>
        /// The <paramref name="services"/> with the decorated command handler registered.
        /// </returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static IServiceCollection DecorateWithValidator<TCommandHandler, TValidator>(
            this IServiceCollection services)
        {
            ServiceDescriptor wrappedDescriptor = services.FirstOrDefault(s => s.ServiceType == typeof(TCommandHandler));

            if (wrappedDescriptor == null)
            {
                throw new InvalidOperationException($"{typeof(TCommandHandler).Name} is not registered");
            }

            if (wrappedDescriptor.ServiceType.GetGenericTypeDefinition() != typeof(ICommandHandler<,>))
            {
                throw new InvalidOperationException($"{typeof(TCommandHandler).Name} is not of type {typeof(ICommandHandler<,>).Name}");
            }

            List<Type> arguments = wrappedDescriptor.ServiceType.GetGenericArguments().ToList();

            Type validatorInterface = typeof(TValidator)
                .GetInterfaces()
                .FirstOrDefault(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IValidator<>));

            if (validatorInterface == null)
            {
                throw new InvalidOperationException($"{typeof(TValidator).Name} is not of type {typeof(IValidator<>).Name}");
            }

            if (validatorInterface.GetGenericArguments()[0] != arguments[0])
            {
                throw new InvalidOperationException("Type arguments don't match for command handler and validator.");
            }

            Type validationCommandHandlerType = typeof(ValidationCommandHandler<,>)
                .MakeGenericType(arguments[0], arguments[1]);

            ObjectFactory objectFactory = ActivatorUtilities.CreateFactory(
                validationCommandHandlerType,
                new[] { typeof(TCommandHandler), typeof(TValidator) }
            );

            ServiceDescriptor validatorServiceDescriptor = new ServiceDescriptor(validatorInterface, typeof(TValidator), wrappedDescriptor.Lifetime);

            services.TryAdd(validatorServiceDescriptor);

            services.Replace(ServiceDescriptor.Describe(
                typeof(TCommandHandler),
                s => (TCommandHandler)objectFactory(s, new[] { s.CreateInstance(wrappedDescriptor), s.CreateInstance(validatorServiceDescriptor) }),
                wrappedDescriptor.Lifetime)
            );

            return services;
        }

        private static object CreateInstance(this IServiceProvider services,
            ServiceDescriptor descriptor)
        {
            if (descriptor.ImplementationInstance != null)
                return descriptor.ImplementationInstance;

            if (descriptor.ImplementationFactory != null)
                return descriptor.ImplementationFactory(services);

            return ActivatorUtilities.GetServiceOrCreateInstance(services, descriptor.ImplementationType);
        }
    }
}