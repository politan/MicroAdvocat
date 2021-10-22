using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MicroAdvocate.Persistence.Database.Entities;
using Microsoft.EntityFrameworkCore.Storage;

namespace MicroAdvocate.Persistence.Database.Repositories
{
    public interface IRepositoryAsync<TEntity>
        where TEntity: Entity
    {
        Task AddAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> expression = null);
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression = null);
        IQueryable<TEntity> Entities { get; }
    }
}