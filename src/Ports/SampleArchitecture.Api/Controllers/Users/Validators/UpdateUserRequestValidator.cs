using FluentValidation;
using SampleArchitecture.Api.Controllers.Users.Requests;

namespace SampleArchitecture.Api.Controllers.Users.Validators
{
    /// <summary>
    /// The update user request validator.
    /// </summary>
    /// <seealso cref="AbstractValidator{T}" />
    internal sealed class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="UpdateUserRequestValidator" />.
        /// </summary>
        public UpdateUserRequestValidator()
        {
            RuleFor(x => x.User).NotNull();
            RuleFor(x => x.User.FirstName).NotEmpty();
            RuleFor(x => x.User.Id).NotEmpty();
            RuleFor(x => x.User.LastName).NotEmpty();
        }
    }
}