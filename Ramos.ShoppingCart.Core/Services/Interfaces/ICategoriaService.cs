using Ramos.ShoppingCart.Domain.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ramos.ShoppingCart.Core.Services.Interfaces
{
    public interface ICategoriaService
    {
        Task<IEnumerable<Categoria>> GetAllAsync();
        
        Task<bool> UpdateAsync(int id, Categoria model);

        Task<bool> CrateAsync(Categoria model);

        Task<bool> DeleteAsync(int id);
    }
}
