using Microsoft.AspNetCore.Mvc;
using SampleArchitecture.Api.Controllers.Users.Requests;
using SampleArchitecture.Commands;

namespace SampleArchitecture.Api.Controllers.Users
{
    /// <summary>
    /// The users controller.
    /// </summary>
    /// <seealso cref="ControllerBase"/>
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly ICommandProcessor _commandProcessor;

        public UsersController(ICommandProcessor commandProcessor)
        {
            _commandProcessor = commandProcessor;
        }

        [HttpDelete("id")]
        public async Task<ActionResult<bool>> Delete(Guid id, CancellationToken cancellationToken)
        {
            var result = await _commandProcessor.HandleAsync<DeleteUserByIdRequest, bool>(
                new DeleteUserByIdRequest
                {
                    Id = id,
                },
                cancellationToken
            );

            return Ok(result);
        }
    }
}
