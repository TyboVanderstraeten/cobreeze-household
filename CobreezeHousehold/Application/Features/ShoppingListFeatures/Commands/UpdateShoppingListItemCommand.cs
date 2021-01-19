using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ShoppingListFeatures.Commands
{
    public class UpdateShoppingListItemCommand : IRequest<Response<ShoppingListItem>>
    {
        public int ShoppingListId { get; set; }

        public int Id { get; set; }
        public string Description { get; set; }
        public int RecipientId { get; set; }

        public class UpdateShoppingListItemCommandHandler : IRequestHandler<UpdateShoppingListItemCommand, Response<ShoppingListItem>>
        {
            private readonly IShoppingListRepositoryAsync _shoppingListRepository;

            public UpdateShoppingListItemCommandHandler(IShoppingListRepositoryAsync shoppingListRepository)
            {
                _shoppingListRepository = shoppingListRepository;
            }

            public async Task<Response<ShoppingListItem>> Handle(UpdateShoppingListItemCommand command, CancellationToken cancellationToken)
            {
                ShoppingList shoppingList = await _shoppingListRepository.GetByIdAsync(command.ShoppingListId, cancellationToken);

                if (shoppingList == null)
                {
                    throw new ApiException("Shopping List Not Found.");
                }

                ShoppingListItem item = shoppingList.GetShoppingListItemById(command.Id);
                item.Description = command.Description;
                item.RecipientId = command.RecipientId;
                
                /*
                 * TODO: does this update? Or entityState needs to be set to modified?
                 */
                await _shoppingListRepository.UpdateAsync(shoppingList, cancellationToken);

                return new Response<ShoppingListItem>(item);
            }
        }
    }
}
