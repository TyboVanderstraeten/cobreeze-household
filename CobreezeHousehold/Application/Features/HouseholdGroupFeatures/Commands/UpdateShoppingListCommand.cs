using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.HouseholdGroupFeatures.Commands
{
    public class UpdateShoppingListCommand : IRequest<Response<ShoppingList>>
    {
        public int HouseholdId { get; set; }

        public int ShoppingListId { get; set; }
        public string Name { get; set; }

        public class UpdateShoppingListCommandHandler : IRequestHandler<UpdateShoppingListCommand, Response<ShoppingList>>
        {
            private readonly IHouseholdGroupRepositoryAsync _householdGroupRepositoryAsync;

            public UpdateShoppingListCommandHandler(IHouseholdGroupRepositoryAsync householdGroupRepositoryAsync)
            {
                _householdGroupRepositoryAsync = householdGroupRepositoryAsync;
            }

            public async Task<Response<ShoppingList>> Handle(UpdateShoppingListCommand command, CancellationToken cancellationToken)
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

                shoppingList.Name = command.Name;

                await _householdGroupRepositoryAsync.UpdateAsync(household, cancellationToken);

                return new Response<ShoppingList>(shoppingList);
            }
        }
    }
}
