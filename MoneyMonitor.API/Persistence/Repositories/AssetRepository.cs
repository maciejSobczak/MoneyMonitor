using Microsoft.EntityFrameworkCore;
using MoneyMonitor.API.Domain.Models;
using MoneyMonitor.API.Domain.Repositories;
using MoneyMonitor.API.Persistence.Contexts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneyMonitor.API.Persistence.Repositories
{
    public class AssetRepository : BaseRepository, IAssetRepository
    {
        public AssetRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Asset>> ListAsync()
        {
            return await _context.Assets.Include(p => p.AssetType).ToListAsync();
        }

        public async Task AddAsync(Asset asset)
        {
            await _context.Assets.AddAsync(asset);
        }

        public async Task<Asset> FindByIdAsync(int id)
        {
            return await _context.Assets.Include(p => p.AssetType).FirstOrDefaultAsync(p => p.Id == id);
        }

        public void Update(Asset asset)
        {
            _context.Assets.Update(asset);
        }

        public void Delete(Asset asset)
        {
            _context.Assets.Remove(asset);
        }
    }
}
