using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MicroAdvocate.Persistence.Database.Contexts;
using MicroAdvocate.Persistence.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace MicroAdvocate.Persistence.Database.Repositories
{
    public class RepositoryAsync<TEntity> : IRepositoryAsync<TEntity>
        where TEntity : Entity
    {
        private readonly DatabaseContext _databaseContext;

        public RepositoryAsync(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _databaseContext.Set<TEntity>().AddAsync(entity);
        }

        public Task DeleteAsync(TEntity entity)
        {
            _databaseContext.Set<TEntity>().Remove(entity);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(TEntity entity)
        {
            _databaseContext.Attach(entity);
            _databaseContext.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _databaseContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            return await _databaseContext.Set<TEntity>().FirstOrDefaultAsync(expression);
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression = null)
        {
            var result = _databaseContext.Set<TEntity>().AsNoTracking();

            if (expression is not null)
                result = result.Where(expression);

            return result;
        }

        public IQueryable<TEntity> Entities => _databaseContext.Set<TEntity>();
    }
}