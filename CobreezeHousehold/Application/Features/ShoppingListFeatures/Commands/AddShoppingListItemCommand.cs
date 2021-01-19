using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ShoppingListFeatures.Commands
{
    public class AddShoppingListItemCommand : IRequest<Response<ShoppingListItem>>
    {
        public int ShoppingListId { get; set; }

        public string Description { get; set; }
        public int RecipientId { get; set; }

        public class AddShoppingListItemCommandHandler : IRequestHandler<AddShoppingListItemCommand, Response<ShoppingListItem>>
        {
            private readonly IShoppingListRepositoryAsync _shoppingListRepository;

            public AddShoppingListItemCommandHandler(IShoppingListRepositoryAsync shoppingListRepository)
            {
                _shoppingListRepository = shoppingListRepository;
            }

            public async Task<Response<ShoppingListItem>> Handle(AddShoppingListItemCommand command, CancellationToken cancellationToken)
            {
                ShoppingList shoppingList = await _shoppingListRepository.GetByIdAsync(command.ShoppingListId, cancellationToken);

                if (shoppingList == null)
                {
                    throw new ApiException("Shopping List Not Found.");
                }

                ShoppingListItem item = new ShoppingListItem(command.Description);
                item.RecipientId = command.RecipientId;

                shoppingList.AddShoppingListItem(item);

                await _shoppingListRepository.UpdateAsync(shoppingList, cancellationToken);

                return new Response<ShoppingListItem>(item);
            }
        }
    }
}
