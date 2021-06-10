using app.api.Core;
using app.api.Features.Productos.Dtos;
using app.api.Features.Productos.Services;
using app.api.SharedKernel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.api.Features.Clientes
{
    public class ClientesService : GenericService<Cliente, ClienteDto, string>
    {
        public ClientesService(IGenericRepository<Cliente, string> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
