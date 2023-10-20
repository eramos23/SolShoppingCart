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
    public class CompraCabeceraService : ICompraCabeceraService
    {
        private readonly IDataManager DataManager;

        public CompraCabeceraService(IDataManager dataManager)
        {
            this.DataManager = dataManager;
        }
        public async Task<bool> CrateAsync(CompraCabecera model)
        {
            DataManager.DbContext.CompraCabecera.Add(model);
            var result = await DataManager.SaveChanges();
            return result > 0;
        }

    }
}
