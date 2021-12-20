﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TranslatorApp.Core.Repositories;

namespace TranslatorApp.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
            => await _dbSet.AddAsync(entity);

        public async Task<IEnumerable<TEntity>> GetAllAsync()
            => await _dbSet.ToListAsync();

        public async Task<TEntity> GetByIdAsync(int id)
            => await _dbSet.FindAsync(id);

        public void Remove(TEntity entity)
            => _dbSet.Remove(entity);

        public void RemoveRange(IEnumerable<TEntity> entities)
            => _dbSet.RemoveRange(entities);

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
            => await _dbSet.SingleOrDefaultAsync(predicate);

        public TEntity Update(TEntity entity)
        {
            // It is not a very performant method,
            // but I wrote it this way because i thought it could be ignored :)
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public async Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate)
            => await _dbSet.Where(predicate).ToListAsync();
    }
}
