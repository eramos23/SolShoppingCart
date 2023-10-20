using AutoMapper;
using Ramos.ShoppingCart.Domain.DbModel;
using Ramos.ShoppingCart.Shared.Dto;

namespace Ramos.ShoppingCart.ApiRest.Profiles
{
    public class ProductoProfile : Profile
    {
        public ProductoProfile()
        {
            CreateMap<Producto, ProductoDto>();
            CreateMap<ProductoDto, Producto>();
            CreateMap<PostProductoDto,Producto>();
            CreateMap<PutProductoDto,Producto>();
        }
    }
}
