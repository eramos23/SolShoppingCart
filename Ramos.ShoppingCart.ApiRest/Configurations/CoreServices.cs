using Ramos.ShoppingCart.Domain.DbContexts.Interfaces;
using Ramos.ShoppingCart.Domain.DbContexts;
using Ramos.ShoppingCart.Core.Services.Interfaces;
using Ramos.ShoppingCart.Core.Services;

namespace Ramos.ShoppingCart.ApiRest.Configurations
{
    public static class CoreServices
    {
        public static void AddCoreServices(this IServiceCollection services)
        {
            services.AddTransient<IDataManager, RepositoryManager>();
            services.AddScoped<IProductoService, ProductoService>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<ICompraCabeceraService, CompraCabeceraService>();
        }
    }
}
