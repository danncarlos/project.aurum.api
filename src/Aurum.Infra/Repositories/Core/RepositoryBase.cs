using Aurum.Domain.Repositories;
using Aurum.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurum.Infra.Repositories.Core {
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class {

        protected readonly BaseAppDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public RepositoryBase(BaseAppDbContext context) {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<TEntity> GetByIdAsync(Guid id, params string[] includeProperties) {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }

            return await query.FirstAsync(e => EF.Property<Guid>(e, "Id") == id);

            //return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(params string[] includeProperties) {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }

            return await query.ToListAsync();
            //return await _dbSet.ToListAsync();
        }

        public async Task AddAsync(TEntity entity) {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity) {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id) {
            var entity = await GetByIdAsync(id);
            if (entity != null) {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(Guid id) {
            return await _dbSet.AnyAsync(e => EF.Property<Guid>(e, "Id") == id);
        }

    }
}
