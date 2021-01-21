using Application.Features.ShoppingListFeatures.Commands;
using Application.Features.ShoppingListFeatures.Queries;
using Application.Filters;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> GetAllHouseholdsByUserId(int id)
        {
            return Ok(await Mediator.Send(new GetAllShoppingListItemsByShoppingListIdQuery() { Id = id }));
        }

        /// <summary>
        /// Creates a New Shopping List Item.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Items")]
        public async Task<IActionResult> AddShoppingListItem(AddShoppingListItemCommand command)
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
        public async Task<IActionResult> UpdateShoppingListItem([FromQuery] int id, UpdateShoppingListItemCommand command)
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
        public async Task<IActionResult> DeleteShoppingListItem(DeleteShoppingListItemByIdCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
