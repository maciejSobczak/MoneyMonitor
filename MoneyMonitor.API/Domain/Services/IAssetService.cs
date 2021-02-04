using MoneyMonitor.API.Domain.Models;
using MoneyMonitor.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneyMonitor.API.Domain.Services
{
    public interface IAssetService
    {
        Task<IEnumerable<Asset>> ListAsync();
        Task<SaveAssetResponse> SaveAsync(Asset asset);
        Task<SaveAssetResponse> UpdateAsync(int Id, Asset asset);
    }
}
