using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ramos.ShoppingCart.Shared.Dto
{
    public class ProductoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public decimal Precio { get; set; }
        public CategoriaDto Categoria { get; set; }
    }
    public class PostProductoDto
    {
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int CategoriaId { get; set; }
    }

    public class PutProductoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
    }
}
