using Microsoft.EntityFrameworkCore;
using Ramos.ShoppingCart.Domain.DbModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ramos.ShoppingCart.Domain.DbContexts
{
    public partial class ShoppingCartDbContext: DbContext
    {
        public ShoppingCartDbContext()
        {
            
        }
        public ShoppingCartDbContext(DbContextOptions<ShoppingCartDbContext> options): base(options) 
        {
                
        }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<CompraCabecera> CompraCabecera { get; set; }
        public DbSet<CompraDetalle> CompraDetalle { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>().HasQueryFilter(c => c.Vigente);

            modelBuilder.Entity<Producto>().HasQueryFilter(p => p.Vigente);
            modelBuilder.Entity<Producto>().Property(p => p.Vigente).HasDefaultValue(1);
            modelBuilder.Entity<Producto>().Property(p => p.FechaCreacion).HasDefaultValueSql("getdate()");


            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
