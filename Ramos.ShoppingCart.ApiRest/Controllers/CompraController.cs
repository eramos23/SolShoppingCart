using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Ramos.ShoppingCart.ApiRest.Shared.Base;
using Ramos.ShoppingCart.ApiRest.Shared.Helpers;
using Ramos.ShoppingCart.ApiRest.Shared.Models;
using Ramos.ShoppingCart.Core.Services;
using Ramos.ShoppingCart.Core.Services.Interfaces;
using Ramos.ShoppingCart.Domain.DbModel;
using Ramos.ShoppingCart.Shared.Dto;
using Ramos.ShoppingCart.Shared.Text;
using System.Net;

namespace Ramos.ShoppingCart.ApiRest.Controllers
{
    [Route("api/compra")]
    [ApiController]
    [Produces("application/json")]
    public class CompraController : BaseController
    {
        private readonly IMapper mapper;
        public readonly ICompraCabeceraService compraCabeceraService;

        public CompraController(IMapper mapper, ICompraCabeceraService _compraCabeceraService) : base(mapper)
        {
            this.mapper = mapper;
            this.compraCabeceraService = _compraCabeceraService;
        }

        /// <summary>
        /// Método para registrar un Producto.
        /// </summary>
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ResultDto<bool>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResultDto<bool>))]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] PostCompraCabeceraDto dto)
        {
            ResultDto<bool> result;
            if (dto == null) return BadRequest(HelperStatus.ResponseHelper(false, HttpStatusCode.BadRequest, Messages.Result_BadRequest));
            var producto = mapper.Map<CompraCabecera>(dto);
            var resultService = await compraCabeceraService.CrateAsync(producto);
            if (resultService)
            {
                result = HelperStatus.ResponseHelper(resultService, HttpStatusCode.Created);
                return StatusCode(StatusCodes.Status201Created, result);
            }
            result = HelperStatus.ResponseHelper(false, HttpStatusCode.BadRequest, Messages.Result_NotCreated);
            return BadRequest(result);
        }
    }
}
