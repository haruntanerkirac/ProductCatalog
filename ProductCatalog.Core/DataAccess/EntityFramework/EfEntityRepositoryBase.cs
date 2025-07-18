using Microsoft.EntityFrameworkCore;
using ProductCatalog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity> where TEntity : class, IEntity ,new()
        where TContext : DbContext
    {
        private readonly TContext _context;

        public EfEntityRepositoryBase(TContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            //_context.Entry(entity).State = EntityState.Modified;
            //await _context.SaveChangesAsync();

            var trackedEntity = await _context.Set<TEntity>().FindAsync(entity.Id);
            if (trackedEntity is null)
                throw new Exception("Entity not found");

            _context.Entry(trackedEntity).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
        }
    }
}
