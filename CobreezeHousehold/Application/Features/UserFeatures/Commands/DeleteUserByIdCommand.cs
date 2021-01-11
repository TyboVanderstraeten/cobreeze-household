using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.UserFeatures.Commands
{
    public class DeleteUserByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }

        public class DeleteUserByIdCommandHandler : IRequestHandler<DeleteUserByIdCommand, Response<int>>
        {
            private readonly IGenericRepositoryAsync<User> _userRepository;

            public DeleteUserByIdCommandHandler(IGenericRepositoryAsync<User> userRepository)
            {
                _userRepository = userRepository;
            }

            public async Task<Response<int>> Handle(DeleteUserByIdCommand command, CancellationToken cancellationToken)
            {
                User user = await _userRepository.GetByIdAsync(command.Id, cancellationToken);

                if (user == null)
                {
                    throw new ApiException("User Not Found.");
                }

                await _userRepository.DeleteAsync(user, cancellationToken);

                return new Response<int>(user.Id);
            }
        }
    }
}
