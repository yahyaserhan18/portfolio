using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> FirstOrDefaultAsync();
        Task<T?> GetByIdAsync(object id);

        void Insert(T entity);
        void Update(T entity);
        Task DeleteAsync(object id);
    }
}
