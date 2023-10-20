using AutoMapper;
using Ramos.ShoppingCart.Domain.DbModel;
using Ramos.ShoppingCart.Shared.Dto;

namespace Ramos.ShoppingCart.ApiRest.Profiles
{
    public class CompraProfile : Profile
    {
        public CompraProfile()
        {
            CreateMap<PostCompraCabeceraDto, CompraCabecera>();

            CreateMap<PostCompraDetalleDto, CompraDetalle>();
        }
    }
}
