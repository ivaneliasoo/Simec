using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.api.SharedKernel
{
    public interface IGenericRepository<T, D> where T : IAggregateRoot
    {
        Task<T> GetByIdAsync(D id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task DeleteAsync(D id);
        IQueryable<T> GetAll();
    }
}