using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private readonly AppDbContext _Context;
        private IGenericRepository<T>? _entity;

        public UnitOfWork(AppDbContext context)
        {
            _Context = context;
        }
        public IGenericRepository<T> Entity
        {
            get
            {
               return _entity ??= new GenericRepository<T>(_Context);
            }
        }

        public void Dispose()
        {
           _Context.Dispose();
        }

        public async Task SaveChangesAsync()
        {
          await _Context.SaveChangesAsync();
        }
    }
}
