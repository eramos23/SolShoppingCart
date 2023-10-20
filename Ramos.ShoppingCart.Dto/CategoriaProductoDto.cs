using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ramos.ShoppingCart.Shared.Dto
{
    public class CategoriaProductoDto
    {
        //public int CategoriaId { get; set; }
        public CategoriaDto Categoria { get; set; }
        public bool TienePromocion { get; set; }
    }
}
