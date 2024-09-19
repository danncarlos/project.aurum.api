using Aurum.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurum.Domain.Repositories {
    public interface IRepositoryBase<TEntity> where TEntity : class {
        Task<TEntity> GetByIdAsync(Guid id, params string[] includeProperties);

        Task<IEnumerable<TEntity>> GetAllAsync(params string[] includeProperties);

        Task AddAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(Guid id);

        Task<bool> ExistsAsync(Guid id);
    }
}