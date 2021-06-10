using app.api.SharedKernel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace app.api.Features.Productos.Services
{
    public interface IGenericService<TSource, TTarget, TIdType> where TSource : IAggregateRoot where TTarget : class, new()
    {
        Task Add(TTarget newProducto);
        Task Delete(TIdType idProducto);
        Task Delete(TTarget newProducto);
        Task<TTarget> Get(TIdType idProducto);
        Task<IEnumerable<TTarget>> GetAll();
        Task Update(TTarget newProducto);
    }
}