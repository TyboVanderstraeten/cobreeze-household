﻿using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.UserFeatures.Commands
{
    public class DeleteUserByIdCommand : IRequest<Response<User>>
    {
        public int Id { get; set; }

        public class DeleteUserByIdCommandHandler : IRequestHandler<DeleteUserByIdCommand, Response<User>>
        {
            private readonly IUserRepositoryAsync _userRepository;

            public DeleteUserByIdCommandHandler(IUserRepositoryAsync userRepository)
            {
                _userRepository = userRepository;
            }

            public async Task<Response<User>> Handle(DeleteUserByIdCommand command, CancellationToken cancellationToken)
            {
                User user = await _userRepository.GetByIdAsync(command.Id, cancellationToken);

                if (user == null)
                {
                    throw new ApiException("User Not Found.");
                }

                await _userRepository.DeleteAsync(user, cancellationToken);

                return new Response<User>(user);
            }
        }
    }
}
