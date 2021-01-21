using Application.Features.ShoppingListFeatures.Commands;
using Application.Features.ShoppingListFeatures.Queries;
using Application.Filters;
using Application.Wrappers;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Presentation.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ShoppingListsController : BaseApiController
    {
        /// <summary>
        /// Gets all Shopping List Items by Shopping List Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/Items")]
        public async Task<ActionResult<Response<IReadOnlyCollection<ShoppingListItem>>>> GetAllHouseholdsByUserId(int id)
        {
            return Ok(await Mediator.Send(new GetAllShoppingListItemsByShoppingListIdQuery() { Id = id }));
        }

        /// <summary>
        /// Creates a New Shopping List Item.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Items")]
        public async Task<ActionResult<Response<ShoppingListItem>>> AddShoppingListItem(AddShoppingListItemCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Updates the Shopping List Item Entity based on Id.   
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("Items")]
        public async Task<ActionResult<Response<ShoppingListItem>>> UpdateShoppingListItem([FromQuery] int id, UpdateShoppingListItemCommand command)
        {
            if (id != command.ShoppingListItemId)
            {
                return BadRequest();
            }

            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Deletes a Shopping List Item.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete("Items")]
        public async Task<ActionResult<Response<ShoppingListItem>>> DeleteShoppingListItem(DeleteShoppingListItemByIdCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
