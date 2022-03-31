using FluentValidation;
using SampleArchitecture.Api.Controllers.Users.Requests;

namespace SampleArchitecture.Api.Controllers.Users.Validators
{
    /// <summary>
    /// The insert user request validator.
    /// </summary>
    /// <seealso cref="AbstractValidator{T}" />
    internal sealed class InsertUserRequestValidator : AbstractValidator<InsertUserRequest>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="InsertUserRequestValidator" />.
        /// </summary>
        public InsertUserRequestValidator()
        {
            RuleFor(x => x.User).NotNull();
            RuleFor(x => x.User.FirstName).NotEmpty();
            RuleFor(x => x.User.Id).Empty();
            RuleFor(x => x.User.LastName).NotEmpty();
        }
    }
}