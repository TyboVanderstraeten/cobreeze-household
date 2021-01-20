using Application.Features.UserFeatures.Commands;
using Application.Features.UserFeatures.Queries;
using Application.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Presentation.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class UsersController : BaseApiController
    {
        /// <summary>
        /// Gets all Users.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationFilter paginationFilter)
        {
            return Ok(await Mediator.Send(new GetAllUsersQuery() { PageNumber = paginationFilter.PageNumber, PageSize = paginationFilter.PageSize }));
        }

        /// <summary>
        /// Gets User Entity by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetUserByIdQuery { Id = id }));
        }

        /// <summary>
        /// Creates a New User.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Updates the User Entity based on Id.   
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] int id, UpdateUserCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Deletes User Entity based on Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteUserByIdCommand { Id = id }));
        }

        /// <summary>
        /// Gets all Households by User Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/Households")]
        public async Task<IActionResult> GetAllHouseholdsByUserId(int id, [FromQuery] PaginationFilter paginationFilter)
        {
            return Ok(await Mediator.Send(new GetAllHouseholdsByUserIdQuery() { Id = id, PageNumber = paginationFilter.PageNumber, PageSize = paginationFilter.PageSize }));
        }
    }
}
