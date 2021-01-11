using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.UserFeatures.Commands
{
    public class UpdateUserCommand : IRequest<Response<User>>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nickname { get; set; }
        public string PhoneNumber { get; set; }

        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Response<User>>
        {
            private readonly IUserRepositoryAsync _userRepository;

            public UpdateUserCommandHandler(IUserRepositoryAsync userRepository)
            {
                _userRepository = userRepository;
            }

            public async Task<Response<User>> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
            {
                User user = await _userRepository.GetByIdAsync(command.Id, cancellationToken);

                if (user == null)
                {
                    throw new ApiException("User Not Found.");
                }

                user.FirstName = command.FirstName;
                user.LastName = command.LastName;
                user.DateOfBirth = command.DateOfBirth;
                user.Nickname = command.Nickname;
                user.PhoneNumber = command.PhoneNumber;

                await _userRepository.UpdateAsync(user, cancellationToken);

                return new Response<User>(user);
            }
        }
    }
}
