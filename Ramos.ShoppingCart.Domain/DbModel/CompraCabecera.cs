using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ramos.ShoppingCart.Domain.DbModel
{
    public class CompraCabecera
    {
        public int Id { get; set; }
        [Precision(10,2)]
        public decimal Total { get; set; }
        public List<CompraDetalle> CompraDetalle { get; set; }
    }
}
