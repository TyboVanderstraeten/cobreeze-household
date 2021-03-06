﻿using Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IUserRepositoryAsync : IGenericRepositoryAsync<User>
    {
        Task<IReadOnlyCollection<HouseholdGroup>> GetAllHouseholdsByUserIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
