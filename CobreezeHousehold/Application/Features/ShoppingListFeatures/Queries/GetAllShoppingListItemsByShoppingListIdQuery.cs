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
    public class GetAllShoppingListItemsByShoppingListIdQuery : IRequest<Response<IReadOnlyCollection<ShoppingListItem>>>
    {
        public int Id { get; set; }

        public class GetAllShoppingListItemsByShoppingListIdQueryHandler : IRequestHandler<GetAllShoppingListItemsByShoppingListIdQuery, Response<IReadOnlyCollection<ShoppingListItem>>>
        {
            private readonly IShoppingListRepositoryAsync _shoppingListRepository;

            public GetAllShoppingListItemsByShoppingListIdQueryHandler(IShoppingListRepositoryAsync shoppingListRepository)
            {
                _shoppingListRepository = shoppingListRepository;
            }

            public async Task<Response<IReadOnlyCollection<ShoppingListItem>>> Handle(GetAllShoppingListItemsByShoppingListIdQuery query, CancellationToken cancellationToken)
            {
                IReadOnlyCollection<ShoppingListItem> items = await _shoppingListRepository.GetAllShoppingListItemsByShoppingListIdAsync(query.Id, cancellationToken);

                if (items == null)
                {
                    throw new ApiException("Shopping List Items Not Found.");
                }

                return new Response<IReadOnlyCollection<ShoppingListItem>>(items);
            }
        }
    }
}
