using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ramos.ShoppingCart.Domain.DbModel
{
    public class CompraDetalle
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CompraCabeceraId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        [Precision(10,2)]
        public decimal Precio { get; set; }
        public Producto Producto { get; set; }
        public CompraCabecera CompraCabecera { get; set; }
    }
}
