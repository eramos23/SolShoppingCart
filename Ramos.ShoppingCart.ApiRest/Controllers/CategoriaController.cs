using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Ramos.ShoppingCart.ApiRest.Shared.Base;
using Ramos.ShoppingCart.ApiRest.Shared.Helpers;
using Ramos.ShoppingCart.ApiRest.Shared.Models;
using Ramos.ShoppingCart.Core.Services.Interfaces;
using Ramos.ShoppingCart.Domain.DbModel;
using Ramos.ShoppingCart.Shared.Dto;
using Ramos.ShoppingCart.Shared.Text;
using System.Diagnostics;
using System.Net;

namespace Ramos.ShoppingCart.ApiRest.Controllers
{
    [Route("api/categoria")]
    [ApiController]
    [Produces("application/json")]
    public class CategoriaController : BaseController
    {
        private readonly IMapper mapper;
        private readonly ICategoriaService categoriaService;

        public CategoriaController(IMapper mapper, ICategoriaService _categoriaService) : base(mapper)
        {
            this.mapper = mapper;
            categoriaService = _categoriaService;
        }

        /// <summary>
        /// Método para listar todas las categorias.
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultDto<List<CategoriaDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResultDto<object>))]
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            ResultDto<IEnumerable<CategoriaDto>> result;
            var list = await this.categoriaService.GetAllAsync();
            if (list.Any())
            {
                result = HelperStatus.ResponseHelper(this.mapper.Map<IEnumerable<CategoriaDto>>(list)/*, traceId*/);
                return Ok(result);
            }
            return NotFound(HelperStatus.ResponseHelper(new List<CategoriaDto>(), HttpStatusCode.NotFound, Messages.Result_Empty));
        }

        /// <summary>
        /// Método para registrar una categoria.
        /// </summary>
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ResultDto<bool>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResultDto<bool>))]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] PostCategoriaDto dto)
        {
            ResultDto<bool> result;
            if (dto == null) return BadRequest(HelperStatus.ResponseHelper(false, HttpStatusCode.BadRequest, Messages.Result_BadRequest));
            var categoria = mapper.Map<Categoria>(dto);
            var resultService = await categoriaService.CrateAsync(categoria);
            if (resultService)
            {
                result = HelperStatus.ResponseHelper(resultService, HttpStatusCode.Created);
                return StatusCode(StatusCodes.Status201Created, result);
            }
            result = HelperStatus.ResponseHelper(false, HttpStatusCode.BadRequest, Messages.Result_NotCreated);
            return BadRequest(result);
        }
        /// <summary>
        /// Método para modificar una categoria.
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultDto<bool>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResultDto<object>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResultDto<bool>))]
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] PutCategoriaDto dto)
        {
            ResultDto<bool> result;
            if (id != dto.Id || dto == null) return BadRequest(HelperStatus.ResponseHelper(false, HttpStatusCode.BadRequest, Messages.Result_BadRequest));
            var categoria = mapper.Map<Categoria>(dto);
            var resultService = await categoriaService.UpdateAsync(id, categoria);
            if (resultService)
            {
                result = HelperStatus.ResponseHelper<bool>(resultService);
                return Ok(result);
            }

            return NotFound(HelperStatus.ResponseHelper<object>(false, HttpStatusCode.NotFound, Messages.Result_Empty));
        }

        /// <summary>
        /// Método para eliminar una categoria por Id.
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultDto<bool>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResultDto<object>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResultDto<bool>))]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest(HelperStatus.ResponseHelper(false, HttpStatusCode.BadRequest, Messages.Result_BadRequest));
            ResultDto<bool> result;
            var resultService = await categoriaService.DeleteAsync(id);
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
