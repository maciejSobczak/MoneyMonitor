using MoneyMonitor.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneyMonitor.API.Domain.Repositories
{
    public interface IAssetRepository
    {
        Task<IEnumerable<Asset>> ListAsync();
        Task AddAsync(Asset asset);
        Task<Asset> FindByIdAsync(int id);
        void Update(Asset asset);
    }
}
