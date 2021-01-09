using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.UserFeatures.Queries
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public int Id { get; set; }

        public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
        {
            private readonly IApplicationDbContext _context;

            public GetUserByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<User> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
            {
                User user = await _context.Users.SingleOrDefaultAsync(u => u.Id == query.Id, cancellationToken);

                if (user == null)
                {
                    return null;
                }

                return user;
            }
        }
    }
}
