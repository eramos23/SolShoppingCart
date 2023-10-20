using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Ramos.ShoppingCart.Core.Services.Interfaces;
using Ramos.ShoppingCart.Domain.DbContexts.Interfaces;
using Ramos.ShoppingCart.Domain.DbModel;
using Ramos.ShoppingCart.Shared.Dto.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ramos.ShoppingCart.Core.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IDataManager DataManager;

        public ProductoService(IDataManager dataManager)
        {
            this.DataManager = dataManager;
        }

        public async Task<bool> CrateAsync(Producto model)
        {
            int result =  await DataManager.ProductoRepository.Add(model);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await this.GetByIdAsync(id);
            if (entity != null)
            {
                entity.Vigente = false;
                var result = await DataManager.SaveChanges();
                return result > 0;
            }
            return false;
        }

        public async Task<List<Producto>> GetAllAsync(FiltroProductoDto filtroDto)
        {
            IQueryable<Producto> query = DataManager.ProductoRepository.GetQueryable().Include(p => p.Categoria);

            if(!string.IsNullOrEmpty(filtroDto.Nombre))
                query = query.Where(p => p.Nombre.Contains(filtroDto.Nombre));

            if(filtroDto.CategoriaId.HasValue)
                query = query.Where(p => p.CategoriaId == filtroDto.CategoriaId);

            return await query.ToListAsync();
        }

        public async Task<Producto> GetByIdAsync(int id)
        {
            var producto = await DataManager.ProductoRepository.FirstOrDefault(p => p.Id == id);
            return producto;
        }

        public async Task<bool> UpdateAsync(int id, Producto model)
        {
            var entity = await this.GetByIdAsync(id);
            
            if (entity != null)
            {
                model.Vigente = entity.Vigente;
                model.CategoriaId = entity.CategoriaId;
                model.UsuarioCreaId = entity.UsuarioCreaId;
                model.FechaCreacion = entity.FechaCreacion;
                var modelsAfected = await DataManager.ProductoRepository.UpdateEntity(model, entity);
                return modelsAfected > 0;
            }
            return false;
        }
    }
}
