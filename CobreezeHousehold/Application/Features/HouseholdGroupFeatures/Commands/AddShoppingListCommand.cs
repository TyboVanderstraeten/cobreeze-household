using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.HouseholdGroupFeatures.Commands
{
    public class AddShoppingListCommand : IRequest<Response<ShoppingList>>
    {
        public int HouseholdId { get; set; }

        public string Name { get; set; }

        public class AddShoppingListCommandHandler : IRequestHandler<AddShoppingListCommand, Response<ShoppingList>>
        {
            private readonly IHouseholdGroupRepositoryAsync _householdGroupRepositoryAsync;

            public AddShoppingListCommandHandler(IHouseholdGroupRepositoryAsync householdGroupRepositoryAsync)
            {
                _householdGroupRepositoryAsync = householdGroupRepositoryAsync;
            }

            public async Task<Response<ShoppingList>> Handle(AddShoppingListCommand command, CancellationToken cancellationToken)
            {
                HouseholdGroup household = await _householdGroupRepositoryAsync.GetByIdAsync(command.HouseholdId, cancellationToken);

                if (household == null)
                {
                    throw new ApiException("Household Not Found.");
                }

                ShoppingList shoppingList = new ShoppingList(command.Name);
                household.ShoppingLists.Add(shoppingList);

                await _householdGroupRepositoryAsync.UpdateAsync(household, cancellationToken);

                return new Response<ShoppingList>(shoppingList);
            }
        }
    }
}
