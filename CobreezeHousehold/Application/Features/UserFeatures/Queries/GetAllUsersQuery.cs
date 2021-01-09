﻿using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.UserFeatures.Queries
{
    public class GetAllUsersQuery : IRequest<IEnumerable<User>>
    {
        public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<User>>
        {
            private readonly IApplicationDbContext _context;

            public GetAllUsersQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<User>> Handle(GetAllUsersQuery query, CancellationToken cancellationToken)
            {
                List<User> userList = await _context.Users.ToListAsync(cancellationToken);

                if (userList == null)
                {
                    return null;
                }

                return userList.AsReadOnly();
            }
        }
    }
}
