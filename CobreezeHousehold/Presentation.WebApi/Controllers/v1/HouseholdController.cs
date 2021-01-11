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
