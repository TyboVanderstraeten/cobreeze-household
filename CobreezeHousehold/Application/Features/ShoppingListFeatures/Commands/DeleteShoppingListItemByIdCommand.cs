using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ShoppingListFeatures.Commands
{
    public class DeleteShoppingListItemByIdCommand : IRequest<Response<ShoppingListItem>>
    {
        public int ShoppingListId { get; set; }

        public int Id { get; set; }

        public class DeleteShoppingListItemByIdCommandHandler : IRequestHandler<DeleteShoppingListItemByIdCommand, Response<ShoppingListItem>>
        {
            private readonly IShoppingListRepositoryAsync _shoppingListRepository;

            public DeleteShoppingListItemByIdCommandHandler(IShoppingListRepositoryAsync shoppingListRepository)
            {
                _shoppingListRepository = shoppingListRepository;
            }

            public async Task<Response<ShoppingListItem>> Handle(DeleteShoppingListItemByIdCommand command, CancellationToken cancellationToken)
            {
                ShoppingList shoppingList = await _shoppingListRepository.GetByIdAsync(command.ShoppingListId, cancellationToken);

                if (shoppingList == null)
                {
                    throw new ApiException("Shopping List Not Found.");
                }

                ShoppingListItem item = shoppingList.GetShoppingListItemById(command.Id);

                if (item == null)
                {
                    throw new ApiException("Shopping List Item Not Found.");
                }

                shoppingList.RemoveShoppingListItem(item);

                await _shoppingListRepository.UpdateAsync(shoppingList, cancellationToken);

                return new Response<ShoppingListItem>(item);
            }
        }
    }
}
