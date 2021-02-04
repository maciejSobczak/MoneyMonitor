using System.Threading.Tasks;

namespace MoneyMonitor.API.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
