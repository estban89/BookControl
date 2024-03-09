﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookControl.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity: class
    {
        protected readonly DbContext context;

        protected RepositoryBase(DbContext context)
        {
            this.context = context;
        }

        public virtual async Task<ICollection<TEntity>> GetAsync()
        {
            return await context.Set<TEntity>()
            .AsNoTracking()
            .ToListAsync();
        }
        public async Task<ICollection<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await context.Set<TEntity>()
                .Where(predicate)
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task<ICollection<TEntity>> GetAsync<TKey>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TKey>> orderBy)
        {
            return await context.Set<TEntity>()
                .Where(predicate)
                .OrderBy(orderBy)
                .AsNoTracking()
                .ToListAsync();
        }
        public virtual async Task<TEntity?> GetAsync(string id)
        {
            return await context.Set<TEntity>()                
                .FindAsync(id);
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            await context.Set<TEntity>()
                .AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }
        public virtual async Task UpdateAsync()
        {
            await context.SaveChangesAsync();
        }
        public async Task DeleteAsync(string id)
        {
            var item = await GetAsync(id);
            if(item is not null)
            {
                context.Set<TEntity>().Remove(item);
                await UpdateAsync();
            }
        }
    }
}
