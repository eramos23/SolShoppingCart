using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ramos.ShoppingCart.Shared.Repositories.Interfaces
{
    public interface IRepositoryManager: IDisposable
    {
        Task<int> SaveChanges();
    }
}
