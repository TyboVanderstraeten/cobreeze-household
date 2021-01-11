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
    public class GetAllUsersQuery : IRequest<PagedResponse<IEnumerable<User>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, PagedResponse<IEnumerable<User>>>
        {
            private readonly IUserRepositoryAsync _userRepository;

            public GetAllUsersQueryHandler(IUserRepositoryAsync userRepository)
            {
                _userRepository = userRepository;
            }

            public async Task<PagedResponse<IEnumerable<User>>> Handle(GetAllUsersQuery query, CancellationToken cancellationToken)
            {
                IReadOnlyList<User> userList = await _userRepository.GetPagedResponseAsync(query.PageNumber, query.PageSize, cancellationToken);

                if (userList == null)
                {
                    throw new ApiException("Users Not Found.");
                }

                return new PagedResponse<IEnumerable<User>>(userList, query.PageNumber, query.PageSize);
            }
        }
    }
}
