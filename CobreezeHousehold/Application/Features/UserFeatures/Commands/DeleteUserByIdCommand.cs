using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.UserFeatures.Commands
{
    public class DeleteUserByIdCommand : IRequest<int>
    {
        public int Id { get; set; }

        public class DeleteUserByIdCommandHandler : IRequestHandler<DeleteUserByIdCommand, int>
        {
            private readonly IApplicationDbContext _context;

            public DeleteUserByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(DeleteUserByIdCommand command, CancellationToken cancellationToken)
            {
                User user = await _context.Users.SingleOrDefaultAsync(u => u.Id == command.Id, cancellationToken);

                if (user == null)
                {
                    return default;
                }

                _context.Users.Remove(user);
                await _context.SaveChangesAsync(cancellationToken);

                return user.Id;
            }
        }
    }
}
