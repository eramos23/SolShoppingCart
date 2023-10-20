using Ramos.ShoppingCart.Shared.Repositories;
using Ramos.ShoppingCart.Shared.Repositories.Interfaces;
using Ramos.ShoppingCart.Domain.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ramos.ShoppingCart.Domain.DbContexts.Interfaces
{
    public interface IDataManager: IRepositoryManager
    {
        IRepository<Categoria> CategoriaRepository { get; }
        IRepository<Producto> ProductoRepository { get; }
        IRepository<CompraCabecera> CompraCabeceraRepository { get; }
        IRepository<CompraDetalle> CompraDetalleRepository { get; }
        ShoppingCartDbContext DbContext { get; }
    }
}
