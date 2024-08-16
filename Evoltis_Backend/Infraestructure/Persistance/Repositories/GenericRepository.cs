﻿using Application.Common.Interfaces.Repositories;
using Application.Common.Models;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infraestructure.Persistance.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> GetByEmailAsync(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(e => EF.Property<string>(e, "Email") == email);
        }

        public async Task<PaginatedList<T>> GetByFiltersWithPaginationAsync(Expression<Func<T, bool>> predicate, int limit, int skip, string orderBy)
        {
            var query = _dbSet.Where(predicate);

            var totalCount = await query.CountAsync();

            var items = await query
                              .OrderByDescending(e => EF.Property<object>(e, orderBy))
                              .Skip(skip)
                              .Take(limit)
                              .ToListAsync();

            return new PaginatedList<T>(items, totalCount, limit, skip);
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(int id, T entity)
        {
            var existingEntity = await GetByIdAsync(id);
            if (existingEntity == null)
            {
                throw new Exception("Entity not found");
            }

            _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();

            return existingEntity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null)
            {
                throw new Exception("Entity not found");
            }

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

    }
}
