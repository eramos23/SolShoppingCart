using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Ramos.ShoppingCart.ApiRest.Shared.Base
{
    public class BaseController: ControllerBase
    {
        private readonly IMapper mapper;

        public BaseController(IMapper mapper)
        {
            this.mapper = mapper;
        }
    }
}
