using FluentValidation;
using SampleArchitecture.Api.Controllers.Users.Requests;

namespace SampleArchitecture.Api.Controllers.Users.Validators
{
    /// <summary>
    /// The get user by identifier request validator.
    /// </summary>
    /// <seealso cref="AbstractValidator{T}" />
    internal sealed class GetUserByIdRequestValidator : AbstractValidator<GetUserByIdRequest>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="GetUserByIdRequestValidator" />.
        /// </summary>
        public GetUserByIdRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}