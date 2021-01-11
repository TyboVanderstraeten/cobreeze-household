using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.UserFeatures.Queries
{
    public class GetAllShoppingListsByHouseholdIdQuery : IRequest<PagedResponse<IEnumerable<ShoppingList>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public int Id { get; set; }

        public class GetAllShoppingListsByHouseholdIdQueryHandler : IRequestHandler<GetAllShoppingListsByHouseholdIdQuery, PagedResponse<IEnumerable<ShoppingList>>>
        {
            private readonly IHouseholdGroupRepositoryAsync _householdGroupRepositoryAsync;

            public GetAllShoppingListsByHouseholdIdQueryHandler(IHouseholdGroupRepositoryAsync householdGroupRepositoryAsync)
            {
                _householdGroupRepositoryAsync = householdGroupRepositoryAsync;
            }

            public async Task<PagedResponse<IEnumerable<ShoppingList>>> Handle(GetAllShoppingListsByHouseholdIdQuery query, CancellationToken cancellationToken)
            {
                IEnumerable<ShoppingList> shoppingLists = await _householdGroupRepositoryAsync.GetAllShoppingListsByHouseholdIdAsync(query.Id, cancellationToken);

                if (shoppingLists == null)
                {
                    throw new ApiException("Shopping Lists Not Found.");
                }

                return new PagedResponse<IEnumerable<ShoppingList>>(shoppingLists, query.PageNumber, query.PageSize);
            }
        }
    }
}
A