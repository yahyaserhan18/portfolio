﻿namespace Core.Interfaces
{
    public interface IUnitOfWork<T> where T : class
    {
        IGenericRepository<T> Entity { get; }
        Task SaveChangesAsync();
        void Dispose();
    }
}
