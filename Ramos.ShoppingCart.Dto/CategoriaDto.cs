using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ramos.ShoppingCart.Shared.Dto
{
    public class CategoriaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        //public CategoriaProductoDto CategoriaProductoDto { get; set; }
    }

    public class PostCategoriaDto
    {
        [Required, StringLength(maximumLength: 150)]
        public string Nombre { get; set; }
    }
    public class PutCategoriaDto
    {
        public int Id { get; set; }
        [Required, StringLength(maximumLength: 150)]
        public string Nombre { get; set; }
        public bool Vigente { get; set; }
    }
}
