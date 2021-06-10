using app.api.Core;
using app.api.Features.Productos.Dtos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.api.Features.Clientes
{
    public class ProductoProfile : Profile
    {
        public ProductoProfile()
        {
            CreateMap<Cliente, ClienteDto>();
            CreateMap<ClienteDto, Cliente>();
        }
    }
}
