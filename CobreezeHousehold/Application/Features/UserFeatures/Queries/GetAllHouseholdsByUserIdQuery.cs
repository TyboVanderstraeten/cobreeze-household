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
    public class GetAllHouseholdsByUserIdQuery : IRequest<PagedResponse<IEnumerable<HouseholdGroup>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public int Id { get; set; }

        public class GetAllHouseholdsByUserIdQueryHandler : IRequestHandler<GetAllHouseholdsByUserIdQuery, PagedResponse<IEnumerable<HouseholdGroup>>>
        {
            private readonly IUserRepositoryAsync _userRepository;

            public GetAllHouseholdsByUserIdQueryHandler(IUserRepositoryAsync userRepository)
            {
                _userRepository = userRepository;
            }

            public async Task<PagedResponse<IEnumerable<HouseholdGroup>>> Handle(GetAllHouseholdsByUserIdQuery query, CancellationToken cancellationToken)
            {
                IReadOnlyList<HouseholdGroup> households = await _userRepository.GetAllHouseholdsByUserIdAsync(query.Id, cancellationToken);

                if (households == null)
                {
                    throw new ApiException("Households Not Found.");
                }

                int totalRecords = await _userRepository.GetCountAsync();

                return new PagedResponse<IEnumerable<HouseholdGroup>>(households, query.PageNumber, query.PageSize, totalRecords);
            }
        }
    }
}
