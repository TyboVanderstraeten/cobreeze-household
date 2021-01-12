using Application.Features.HouseholdGroupFeatures.Commands;
using Application.Features.HouseholdGroupFeatures.Queries;
using Application.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Presentation.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class HouseholdController : BaseApiController
    {
        /// <summary>
        /// Gets all Households.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationFilter paginationFilter)
        {
            return Ok(await Mediator.Send(new GetAllHouseholdsQuery() { PageNumber = paginationFilter.PageNumber, PageSize = paginationFilter.PageSize }));
        }

        /// <summary>
        /// Gets Household Entity by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetHouseholdByIdQuery { Id = id }));
        }

        /// <summary>
        /// Creates a New Household.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateHouseholdCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Updates the Household Entity based on Id.   
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("[action]")]
        public async Task<IActionResult> Update(int id, UpdateHouseholdCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Deletes Household Entity based on Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteHouseholdByIdCommand { Id = id }));
        }

        /// <summary>
        /// Gets all Users by Household Id.
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}/Users")]
        public async Task<IActionResult> GetAllUsersByHouseholdId(int id, [FromQuery] PaginationFilter paginationFilter)
        {
            return Ok(await Mediator.Send(new GetAllUsersByHouseholdIdQuery() { Id = id, PageNumber = paginationFilter.PageNumber, PageSize = paginationFilter.PageSize }));
        }

        /// <summary>
        /// Gets all Tasks by Household Id.
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}/Tasks")]
        public async Task<IActionResult> GetAllTasksByHouseholdId(int id, [FromQuery] PaginationFilter paginationFilter)
        {
            return Ok(await Mediator.Send(new GetAllTasksByHouseholdIdQuery() { Id = id, PageNumber = paginationFilter.PageNumber, PageSize = paginationFilter.PageSize }));
        }

        /// <summary>
        /// Gets all Shopping Lists by Household Id.
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}/Shopping-Lists")]
        public async Task<IActionResult> GetAllShoppingListsByHouseholdId(int id, [FromQuery] PaginationFilter paginationFilter)
        {
            return Ok(await Mediator.Send(new GetAllShoppingListsByHouseholdIdQuery() { Id = id, PageNumber = paginationFilter.PageNumber, PageSize = paginationFilter.PageSize }));
        }
    }
}
