using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ShoppingListFeatures.Queries
{
    public class GetAllShoppingListItemsByShoppingListIdQuery : IRequest<PagedResponse<IEnumerable<ShoppingListItem>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public int Id { get; set; }

        public class GetAllShoppingListItemsByShoppingListIdQueryHandler : IRequestHandler<GetAllShoppingListItemsByShoppingListIdQuery, PagedResponse<IEnumerable<ShoppingListItem>>>
        {
            private readonly IShoppingListRepositoryAsync _shoppingListRepository;

            public GetAllShoppingListItemsByShoppingListIdQueryHandler(IShoppingListRepositoryAsync shoppingListRepository)
            {
                _shoppingListRepository = shoppingListRepository;
            }

            public async Task<PagedResponse<IEnumerable<ShoppingListItem>>> Handle(GetAllShoppingListItemsByShoppingListIdQuery query, CancellationToken cancellationToken)
            {
                IReadOnlyList<ShoppingListItem> items = await _shoppingListRepository.GetAllShoppingListItemsByShoppingListIdAsync(query.Id, cancellationToken);

                if (items == null)
                {
                    throw new ApiException("Shopping List Items Not Found.");
                }

                return new PagedResponse<IEnumerable<ShoppingListItem>>(items, query.PageNumber, query.PageSize, items.Count);
            }
        }
    }
}
