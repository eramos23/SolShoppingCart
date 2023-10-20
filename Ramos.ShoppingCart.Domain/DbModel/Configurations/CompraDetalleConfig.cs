using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ramos.ShoppingCart.Domain.DbModel.Configurations
{
    public class CompraDetalleConfig : IEntityTypeConfiguration<CompraDetalle>
    {
        public void Configure(EntityTypeBuilder<CompraDetalle> builder)
        {
            builder.HasKey(cd => new { cd.Id , cd.CompraCabeceraId});
        }
    }
}
