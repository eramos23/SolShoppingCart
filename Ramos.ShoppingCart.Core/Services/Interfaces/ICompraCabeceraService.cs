using Ramos.ShoppingCart.Domain.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ramos.ShoppingCart.Core.Services.Interfaces
{
    public interface ICompraCabeceraService
    {
        Task<bool> CrateAsync(CompraCabecera model);
    }
}
