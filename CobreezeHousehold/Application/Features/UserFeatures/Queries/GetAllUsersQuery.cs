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
    public class GetAllUsersQuery : IRequest<Response<IReadOnlyCollection<User>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, Response<IReadOnlyCollection<User>>>
        {
            private readonly IUserRepositoryAsync _userRepository;

            public GetAllUsersQueryHandler(IUserRepositoryAsync userRepository)
            {
                _userRepository = userRepository;
            }

            public async Task<Response<IReadOnlyCollection<User>>> Handle(GetAllUsersQuery query, CancellationToken cancellationToken)
            {
                IReadOnlyCollection<User> users = await _userRepository.GetAllAsync(cancellationToken);

                if (users == null)
                {
                    throw new ApiException("Users Not Found.");
                }

                return new Response<IReadOnlyCollection<User>>(users);
            }
        }
    }
}
