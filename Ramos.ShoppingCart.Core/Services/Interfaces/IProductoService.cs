using Ramos.ShoppingCart.Domain.DbModel;
using Ramos.ShoppingCart.Shared.Dto.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ramos.ShoppingCart.Core.Services.Interfaces
{
    public interface IProductoService
    {
        Task<List<Producto>> GetAllAsync(FiltroProductoDto filtroDto);
        Task<Producto> GetByIdAsync(int id);

        Task<bool> UpdateAsync(int id, Producto model);

        Task<bool> CrateAsync(Producto model);

        Task<bool> DeleteAsync(int id);
    }
}
