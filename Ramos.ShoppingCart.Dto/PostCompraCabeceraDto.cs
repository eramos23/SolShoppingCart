using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ramos.ShoppingCart.Shared.Dto
{
    public class PostCompraCabeceraDto
    {
        public decimal Total { get; set; }
        public List<PostCompraDetalleDto> CompraDetalle { get; set; }
    }
}
