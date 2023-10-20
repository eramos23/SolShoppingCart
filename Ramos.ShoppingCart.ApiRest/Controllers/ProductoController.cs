using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Ramos.ShoppingCart.ApiRest.Shared.Base;
using Ramos.ShoppingCart.ApiRest.Shared.Helpers;
using Ramos.ShoppingCart.ApiRest.Shared.Models;
using Ramos.ShoppingCart.Core.Services;
using Ramos.ShoppingCart.Core.Services.Interfaces;
using Ramos.ShoppingCart.Domain.DbModel;
using Ramos.ShoppingCart.Shared.Dto;
using Ramos.ShoppingCart.Shared.Dto.Filters;
using Ramos.ShoppingCart.Shared.Text;
using System.Net;

namespace Ramos.ShoppingCart.ApiRest.Controllers
{
    [Route("api/producto")]
    [ApiController]
    [Produces("application/json")]
    public class ProductoController : BaseController
    {
        private readonly IMapper mapper;
        public readonly IProductoService productoService;

        public ProductoController(IMapper mapper, IProductoService _productoService) : base(mapper)
        {
            this.mapper = mapper;
            this.productoService = _productoService;
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultDto<List<ProductoDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResultDto<object>))]
        [HttpGet]
        public async Task<ActionResult> GetAll([FromQuery] FiltroProductoDto filtroDto)
        {
            ResultDto<List<ProductoDto>> result;
            var list = await this.productoService.GetAllAsync(filtroDto);
            if(list.Any())
            {
                result = HelperStatus.ResponseHelper(this.mapper.Map<List<ProductoDto>>(list)/*, traceId*/);
                return Ok(result);
            }
            return NotFound(HelperStatus.ResponseHelper(new List<ProductoDto>(), HttpStatusCode.NotFound, Messages.Result_Empty));
        }

        /// <summary>
        /// Método para registrar un Producto.
        /// </summary>
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ResultDto<bool>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResultDto<bool>))]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] PostProductoDto dto)
        {
            ResultDto<bool> result;
            if (dto == null) return BadRequest(HelperStatus.ResponseHelper(false, HttpStatusCode.BadRequest, Messages.Result_BadRequest));
            var producto = mapper.Map<Producto>(dto);
            var resultService = await productoService.CrateAsync(producto);
            if (resultService)
            {
                result = HelperStatus.ResponseHelper(resultService, HttpStatusCode.Created);
                return StatusCode(StatusCodes.Status201Created, result);
            }
            result = HelperStatus.ResponseHelper(false, HttpStatusCode.BadRequest, Messages.Result_NotCreated);
            return BadRequest(result);
        }

        /// <summary>
        /// Método para modificar un producto.
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultDto<bool>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResultDto<object>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResultDto<bool>))]
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] PutProductoDto dto)
        {
            ResultDto<bool> result;
            if (id != dto.Id || dto == null) return BadRequest(HelperStatus.ResponseHelper(false, HttpStatusCode.BadRequest, Messages.Result_BadRequest));
            var producto = mapper.Map<Producto>(dto);
            var resultService = await productoService.UpdateAsync(id, producto);
            if (resultService)
            {
                result = HelperStatus.ResponseHelper<bool>(resultService);
                return Ok(result);
            }

            return NotFound(HelperStatus.ResponseHelper<object>(false, HttpStatusCode.NotFound, Messages.Result_Empty));
        }

        /// <summary>
        /// Método para eliminar un producto por Id.
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultDto<bool>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResultDto<object>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResultDto<bool>))]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest(HelperStatus.ResponseHelper(false, HttpStatusCode.BadRequest, Messages.Result_BadRequest));
            ResultDto<bool> result;
            var resultService = await productoService.DeleteAsync(id);
            if (resultService)
            {
                result = HelperStatus.ResponseHelper(resultService);
                return Ok(result);
            }

            result = HelperStatus.ResponseHelper(false, HttpStatusCode.BadRequest, Messages.Result_NotDeleted);
            return BadRequest(result);
        }
    }
}
