using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ramos.ShoppingCart.Domain.DbModel
{
    public class Categoria
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 150)]
        public string Nombre { get; set; } = null!;
        public bool Vigente { get; set; }
        public List<Producto> Productos { get; set; } = new List<Producto>();
    }
}
