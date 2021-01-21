using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.HouseholdGroupFeatures.Queries
{
    public class GetAllShoppingListsByHouseholdIdQuery : IRequest<Response<IReadOnlyCollection<ShoppingList>>>
    {
        public int Id { get; set; }

        public class GetAllShoppingListsByHouseholdIdQueryHandler : IRequestHandler<GetAllShoppingListsByHouseholdIdQuery, Response<IReadOnlyCollection<ShoppingList>>>
        {
            private readonly IHouseholdGroupRepositoryAsync _householdGroupRepositoryAsync;

            public GetAllShoppingListsByHouseholdIdQueryHandler(IHouseholdGroupRepositoryAsync householdGroupRepositoryAsync)
            {
                _householdGroupRepositoryAsync = householdGroupRepositoryAsync;
            }

            public async Task<Response<IReadOnlyCollection<ShoppingList>>> Handle(GetAllShoppingListsByHouseholdIdQuery query, CancellationToken cancellationToken)
            {
                IReadOnlyCollection<ShoppingList> shoppingLists = await _householdGroupRepositoryAsync.GetAllShoppingListsByHouseholdIdAsync(query.Id, cancellationToken);

                if (shoppingLists == null)
                {
                    throw new ApiException("Shopping Lists Not Found.");
                }

                return new Response<IReadOnlyCollection<ShoppingList>>(shoppingLists);
            }
        }
    }
}