using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.UserFeatures.Commands
{
    public class UpdateUserCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nickname { get; set; }
        public string PhoneNumber { get; set; }

        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, int>
        {
            private readonly IApplicationDbContext _context;

            public UpdateUserCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
            {
                User user = await _context.Users.SingleOrDefaultAsync(u => u.Id == command.Id, cancellationToken);

                if (user == null)
                {
                    return default;
                }

                user.FirstName = command.FirstName;
                user.LastName = command.LastName;
                user.DateOfBirth = command.DateOfBirth;
                user.Nickname = command.Nickname;
                user.PhoneNumber = command.PhoneNumber;

                _context.Users.Update(user);
                await _context.SaveChangesAsync(cancellationToken);

                return user.Id;
            }
        }
    }
}
