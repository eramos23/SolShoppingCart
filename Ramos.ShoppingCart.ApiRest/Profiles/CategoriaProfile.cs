using AutoMapper;
using Ramos.ShoppingCart.Domain.DbModel;
using Ramos.ShoppingCart.Shared.Dto;

namespace Ramos.ShoppingCart.ApiRest.Profiles
{
    public class CategoriaProfile : Profile
    {
        public CategoriaProfile()
        {
            CreateMap<Categoria, CategoriaDto>();
            CreateMap<CategoriaDto, Categoria>();
            CreateMap<PostCategoriaDto, Categoria>();
            CreateMap<PutCategoriaDto, Categoria>();
        }
    }
}
