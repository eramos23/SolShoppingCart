using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ramos.ShoppingCart.Shared.Dto
{
    public class PostCompraDetalleDto
    {
        //public int CompraCabeceraId { get; set; }
        public int ProductoId { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }
    }
}
