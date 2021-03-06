﻿using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.HouseholdGroupFeatures.Commands
{
    public class DeleteShoppingListByIdCommand : IRequest<Response<ShoppingList>>
    {
        public int HouseholdId { get; set; }

        public int ShoppingListId { get; set; }

        public class DeleteShoppingListByIdCommandHandler : IRequestHandler<DeleteShoppingListByIdCommand, Response<ShoppingList>>
        {
            private readonly IHouseholdGroupRepositoryAsync _householdGroupRepositoryAsync;

            public DeleteShoppingListByIdCommandHandler(IHouseholdGroupRepositoryAsync householdGroupRepositoryAsync)
            {
                _householdGroupRepositoryAsync = householdGroupRepositoryAsync;
            }

            public async Task<Response<ShoppingList>> Handle(DeleteShoppingListByIdCommand command, CancellationToken cancellationToken)
            {
                HouseholdGroup household = await _householdGroupRepositoryAsync.GetByIdAsync(command.HouseholdId, cancellationToken);

                if (household == null)
                {
                    throw new ApiException("Household Not Found.");
                }

                ShoppingList shoppingList = household.GetShoppingListById(command.ShoppingListId);

                if (shoppingList == null)
                {
                    throw new ApiException("Shopping List Not Found.");
                }

                household.RemoveShoppingList(shoppingList);

                await _householdGroupRepositoryAsync.UpdateAsync(household, cancellationToken);

                return new Response<ShoppingList>(shoppingList);
            }
        }
    }
}
