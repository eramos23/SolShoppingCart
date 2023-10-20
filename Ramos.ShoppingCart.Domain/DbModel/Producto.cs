using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ramos.ShoppingCart.Domain.DbModel
{
    public class Producto
    {
        public int Id { get; set; }
        [StringLength(maximumLength:150)]
        public string Nombre { get; set; } = null!;
        [Precision(5,2)]
        public decimal Precio { get; set; }
        public bool Vigente { get; set; }
        public int UsuarioCreaId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
