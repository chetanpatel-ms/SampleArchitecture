using FluentValidation;
using SampleArchitecture.Api.Controllers.Users.Requests;

namespace SampleArchitecture.Api.Controllers.Users.Validators
{
    /// <summary>
    /// The search users by first name request validator.
    /// </summary>
    /// <seealso cref="AbstractValidator{T}" />
    internal sealed class SearchUsersByFirstNameRequestValidator : AbstractValidator<SearchUsersByFirstNameRequest>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="SearchUsersByFirstNameRequestValidator" />.
        /// </summary>
        public SearchUsersByFirstNameRequestValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
        }
    }
}