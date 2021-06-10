using app.api.Core;
using app.api.Features.Productos.Dtos;
using app.api.Features.Productos.Services;
using app.api.SharedKernel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.api.Features.Productos
{
    public class ProductosService : GenericService<Producto, ProductoDto, short>
    {
        public ProductosService(IGenericRepository<Producto, short> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
