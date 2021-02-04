using MoneyMonitor.API.Persistence.Contexts;

namespace MoneyMonitor.API.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            this._context = context;
        }
    }
}   
