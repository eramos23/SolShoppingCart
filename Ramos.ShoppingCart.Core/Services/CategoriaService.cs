using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Ramos.ShoppingCart.Core.Services.Interfaces;
using Ramos.ShoppingCart.Domain.DbContexts.Interfaces;
using Ramos.ShoppingCart.Domain.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ramos.ShoppingCart.Core.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly IDataManager DataManager;

        public CategoriaService(IDataManager dataManager)
        {
            this.DataManager = dataManager;
        }
        public async Task<bool> CrateAsync(Categoria model)
        {
            int result = await DataManager.CategoriaRepository.Add(model);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await DataManager.CategoriaRepository.GetById(id); 
            if (entity != null) { 
                entity.Vigente = false;
                var result = await DataManager.SaveChanges();
                return result > 0;
            }
            return false;
        }

        public Task<IEnumerable<Categoria>> GetAllAsync()
        {
            return DataManager.CategoriaRepository.GetAll();
        }

        public async Task<bool> UpdateAsync(int id, Categoria model)
        {
            var entity = await DataManager.CategoriaRepository.GetById(id);
            if (entity != null)
            {
                var modelsAfected = await DataManager.CategoriaRepository.UpdateEntity(model, entity);
                return modelsAfected > 0;
            }
            return false;
        }
    }
}
