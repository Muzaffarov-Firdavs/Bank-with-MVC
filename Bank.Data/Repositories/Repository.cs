﻿using Bank.Data.DbContexts;
using Bank.Data.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Bank.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly AppDbContext dbContext;
        private readonly DbSet<TEntity> dbSet;


        public Repository(AppDbContext dbContext, DbSet<TEntity> dbSet)
        {
            this.dbContext = dbContext;
            this.dbContext.Set<TEntity>();
        }

        public async Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> expression)
        {
            var entity = await this.SelectAsync(expression);

            if (entity is not null)
            {
                this.dbSet.Remove(entity);
                return true;
            }

            return false;
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            return (await this.dbSet.AddAsync(entity)).Entity;
        }

        public async Task SaveAsync()
        {
            await dbContext.SaveChangesAsync();
        }

        public IQueryable<TEntity> SelectAll()
            => this.dbSet;

        public async Task<TEntity> SelectAsync(Expression<Func<TEntity, bool>> expression)
        => await this.dbSet.FirstOrDefaultAsync(expression);

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var entry = this.dbSet.Update(entity);

            return await Task.FromResult(entry.Entity);
        }
    }
}
