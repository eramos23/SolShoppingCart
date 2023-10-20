using Ramos.ShoppingCart.Domain.DbContexts.Interfaces;
using Ramos.ShoppingCart.Domain.DbModel;
using Ramos.ShoppingCart.Shared.Repositories;
using Ramos.ShoppingCart.Shared.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ramos.ShoppingCart.Domain.DbContexts
{
    public class RepositoryManager : IDataManager
    {
        private readonly ShoppingCartDbContext Context;

        private readonly IRepository<Categoria> _categoriaRepository;
        private readonly IRepository<Producto> _productoRepository;
        private readonly IRepository<CompraCabecera> _compraCabeceraRepository;
        private readonly IRepository<CompraDetalle> _compraDetalleRepository;
        public RepositoryManager(ShoppingCartDbContext context)
        {
            this.Context = context;
        }
        public IRepository<Categoria> CategoriaRepository => this._categoriaRepository ?? new Repository<Categoria>(this.Context);
        public IRepository<Producto> ProductoRepository => this._productoRepository ?? new Repository<Producto>(this.Context);
        public ShoppingCartDbContext DbContext => this.Context;

        public IRepository<CompraCabecera> CompraCabeceraRepository => this._compraCabeceraRepository ?? new Repository<CompraCabecera>(this.Context);
        public IRepository<CompraDetalle> CompraDetalleRepository => this._compraDetalleRepository ?? new Repository<CompraDetalle>(this.Context);

        void IDisposable.Dispose()
        {
            if (this.Context != null)
            {
                this.Context.Dispose();
            }
        }

        public async Task<int> SaveChanges()
        {
            return await this.Context.SaveChangesAsync();
        }
    }
}
