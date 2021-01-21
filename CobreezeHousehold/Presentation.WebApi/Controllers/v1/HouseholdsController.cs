using Application.Features.HouseholdGroupFeatures.Commands;
using Application.Features.HouseholdGroupFeatures.Queries;
using Application.Filters;
using Application.Wrappers;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        public async Task<ActionResult<Response<HouseholdGroup>>> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetHouseholdByIdQuery { Id = id }));
        }

        /// <summary>
        /// Creates a New Household.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Response<HouseholdGroup>>> Create(CreateHouseholdCommand command)
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
        public async Task<ActionResult<Response<HouseholdGroup>>> Update([FromQuery] int id, UpdateHouseholdCommand command)
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
        public async Task<ActionResult<Response<HouseholdGroup>>> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteHouseholdByIdCommand { Id = id }));
        }

        /// <summary>
        /// Creates a New HouseholdGroupUser.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Members")]
        public async Task<ActionResult<Response<User>>> AddMember(AddMemberCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Deletes a HouseholdGroupUser.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete("Members")]
        public async Task<ActionResult<Response<User>>> DeleteMember(DeleteMemberByIdCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Creates a New Task.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Tasks")]
        public async Task<ActionResult<Response<HouseholdTask>>> AddTask(AddTaskCommand command)
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
        public async Task<ActionResult<Response<HouseholdTask>>> UpdateTask([FromQuery] int id, UpdateTaskCommand command)
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
        public async Task<ActionResult<Response<HouseholdTask>>> DeleteTask(DeleteTaskByIdCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Creates a New Shopping List.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Shopping-Lists")]
        public async Task<ActionResult<Response<ShoppingList>>> AddShoppingList(AddShoppingListCommand command)
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
        public async Task<ActionResult<Response<ShoppingList>>> UpdateShoppingList([FromQuery] int id, UpdateShoppingListCommand command)
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
        public async Task<ActionResult<Response<ShoppingList>>> DeleteShoppingList(DeleteShoppingListByIdCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Gets all Users by Household Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/Users")]
        public async Task<ActionResult<Response<IReadOnlyCollection<User>>>> GetAllUsersByHouseholdId(int id)
        {
            return Ok(await Mediator.Send(new GetAllMembersByHouseholdIdQuery() { Id = id }));
        }

        /// <summary>
        /// Gets all Tasks by Household Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/Tasks")]
        public async Task<ActionResult<Response<IReadOnlyCollection<HouseholdTask>>>> GetAllTasksByHouseholdId(int id)
        {
            return Ok(await Mediator.Send(new GetAllTasksByHouseholdIdQuery() { Id = id }));
        }

        /// <summary>
        /// Gets all Shopping Lists by Household Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/Shopping-Lists")]
        public async Task<ActionResult<Response<IReadOnlyCollection<ShoppingList>>>> GetAllShoppingListsByHouseholdId(int id)
        {
            return Ok(await Mediator.Send(new GetAllShoppingListsByHouseholdIdQuery() { Id = id }));
        }
    }
}
