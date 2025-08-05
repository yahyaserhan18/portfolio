using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<T>() ?? throw new ArgumentNullException(nameof(_dbSet));
        }
        public async Task DeleteAsync(object id)
        {
            T? entity =await GetByIdAsync(id);
            if(entity == null)
            {
                throw new KeyNotFoundException($"Entity with id {id} not found.");
            }
            _dbSet.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> FirstOrDefaultAsync()
        {
            return await _dbSet.FirstOrDefaultAsync();
        }

        public async Task<T?> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }
        //public Task<T?> GetById(object id)
        //{
        //    return _dbSet.FindAsync(id).AsTask();
        //}
        public void Insert(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            //table.Attach(entity);
            //_context.Entry(entity).State = EntityState.Modified;
            _dbSet.Update(entity);
        }
    }
}
