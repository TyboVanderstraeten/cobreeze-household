using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.UserFeatures.Commands
{
    public class CreateUserCommand : IRequest<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nickname { get; set; }
        public string PhoneNumber { get; set; }

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
        {
            private readonly IApplicationDbContext _context;

            public CreateUserCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateUserCommand command, CancellationToken cancellationToken)
            {
                User user = new User(command.FirstName, command.LastName, command.DateOfBirth);
                user.Nickname = command.Nickname;
                user.PhoneNumber = command.PhoneNumber;

                _context.Users.Add(user);
                await _context.SaveChangesAsync(cancellationToken);

                return user.Id;
            }
        }
    }
}
