using app.api.Core;
using app.api.Features.Productos.Dtos;
using AutoMapper;

namespace app.api.Features.Prodcutos
{
    public class ProductoProfile : Profile
    {
        public ProductoProfile()
        {
            CreateMap<Producto, ProductoDto>().ReverseMap();
        }
    }
}
