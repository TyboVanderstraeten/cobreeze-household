using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.UserFeatures.Commands
{
    public class CreateUserCommand : IRequest<Response<int>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nickname { get; set; }
        public string PhoneNumber { get; set; }

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Response<int>>
        {
            private readonly IUserRepositoryAsync _userRepository;

            public CreateUserCommandHandler(IUserRepositoryAsync userRepository)
            {
                _userRepository = userRepository;
            }

            public async Task<Response<int>> Handle(CreateUserCommand command, CancellationToken cancellationToken)
            {
                User user = new User(command.FirstName, command.LastName, command.DateOfBirth);
                user.Nickname = command.Nickname;
                user.PhoneNumber = command.PhoneNumber;

                await _userRepository.AddAsync(user, cancellationToken);

                return new Response<int>(user.Id);
            }
        }
    }
}
