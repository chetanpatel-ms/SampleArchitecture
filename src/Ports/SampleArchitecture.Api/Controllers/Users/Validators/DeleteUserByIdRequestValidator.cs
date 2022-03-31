using FluentValidation;
using SampleArchitecture.Api.Controllers.Users.Requests;

namespace SampleArchitecture.Api.Controllers.Users.Validators
{
    /// <summary>
    /// The delete user by identifier request validator.
    /// </summary>
    /// <seealso cref="AbstractValidator{T}" />
    internal sealed class DeleteUserByIdRequestValidator : AbstractValidator<DeleteUserByIdRequest>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="DeleteUserByIdRequestValidator" />.
        /// </summary>
        public DeleteUserByIdRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}