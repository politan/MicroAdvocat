using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MicroAdvocate.Persistence.Database.Contexts
{
    public abstract class DatabaseContext : DbContext, IDatabaseContext
    {
        protected DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public virtual void RunInTransaction(Action action)
        {
            using var transaction = Database.BeginTransaction();
        
            try
            {
                action.Invoke();
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }

        public virtual async Task RunInTransactionAsync(Func<Task> func)
        {
            await using var transaction = await Database.BeginTransactionAsync();
        
            try
            {
                await func.Invoke();
                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}