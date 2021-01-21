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
    public class GetAllUsersQuery : IRequest<PagedResponse<IReadOnlyCollection<User>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, PagedResponse<IReadOnlyCollection<User>>>
        {
            private readonly IUserRepositoryAsync _userRepository;

            public GetAllUsersQueryHandler(IUserRepositoryAsync userRepository)
            {
                _userRepository = userRepository;
            }

            public async Task<PagedResponse<IReadOnlyCollection<User>>> Handle(GetAllUsersQuery query, CancellationToken cancellationToken)
            {
                PagedResponse<IReadOnlyCollection<User>> users = await _userRepository.GetPagedResponseAsync(query.PageNumber, query.PageSize, cancellationToken);

                if (users.Data == null)
                {
                    throw new ApiException("Users Not Found.");
                }

                return users;
            }
        }
    }
}
