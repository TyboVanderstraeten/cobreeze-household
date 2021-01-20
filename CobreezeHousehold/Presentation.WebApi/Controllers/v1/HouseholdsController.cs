using Application.Features.HouseholdGroupFeatures.Commands;
using Application.Features.HouseholdGroupFeatures.Queries;
using Application.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Presentation.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class HouseholdsController : BaseApiController
    {
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
        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] int id, UpdateHouseholdCommand command)
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
        /// Creates a New HouseholdGroupUser.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Members")]
        public async Task<IActionResult> AddMember(AddMemberCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Deletes a HouseholdGroupUser.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete("Members")]
        public async Task<IActionResult> DeleteMember(DeleteMemberByIdCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Creates a New Task.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Tasks")]
        public async Task<IActionResult> AddTask(AddTaskCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Updates the Task Entity based on Id.   
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("Tasks")]
        public async Task<IActionResult> UpdateTask([FromQuery] int id, UpdateTaskCommand command)
        {
            if (id != command.TaskId)
            {
                return BadRequest();
            }

            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Deletes a Task.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete("Tasks")]
        public async Task<IActionResult> DeleteTask(DeleteTaskByIdCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Creates a New Shopping List.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Shopping-Lists")]
        public async Task<IActionResult> AddShoppingList(AddShoppingListCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Updates the Shopping List Entity based on Id.   
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("Shopping-Lists")]
        public async Task<IActionResult> UpdateShoppingList([FromQuery] int id, UpdateShoppingListCommand command)
        {
            if (id != command.ShoppingListId)
            {
                return BadRequest();
            }

            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Deletes a Shopping List.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete("Shopping-Lists")]
        public async Task<IActionResult> DeleteShoppingList(DeleteShoppingListByIdCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Gets all Users by Household Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/Users")]
        public async Task<IActionResult> GetAllUsersByHouseholdId(int id, [FromQuery] PaginationFilter paginationFilter)
        {
            return Ok(await Mediator.Send(new GetAllMembersByHouseholdIdQuery() { Id = id, PageNumber = paginationFilter.PageNumber, PageSize = paginationFilter.PageSize }));
        }

        /// <summary>
        /// Gets all Tasks by Household Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/Tasks")]
        public async Task<IActionResult> GetAllTasksByHouseholdId(int id, [FromQuery] PaginationFilter paginationFilter)
        {
            return Ok(await Mediator.Send(new GetAllTasksByHouseholdIdQuery() { Id = id, PageNumber = paginationFilter.PageNumber, PageSize = paginationFilter.PageSize }));
        }

        /// <summary>
        /// Gets all Shopping Lists by Household Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/Shopping-Lists")]
        public async Task<IActionResult> GetAllShoppingListsByHouseholdId(int id, [FromQuery] PaginationFilter paginationFilter)
        {
            return Ok(await Mediator.Send(new GetAllShoppingListsByHouseholdIdQuery() { Id = id, PageNumber = paginationFilter.PageNumber, PageSize = paginationFilter.PageSize }));
        }
    }
}
