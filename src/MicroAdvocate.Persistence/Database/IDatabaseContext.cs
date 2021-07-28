using System;
using System.Threading.Tasks;

namespace MicroAdvocate.Persistence.Database
{
    public interface IDatabaseContext
    {
        void RunInTransaction(Action action);
        Task RunInTransactionAsync(Func<Task> func);
    }
}