using System.Net;

namespace Ramos.ShoppingCart.ApiRest.Shared.Models
{
    public class StatusDto
    {
        public HttpStatusCode HttpCode { get; set; }

        public string Message { get; set; }
    }
}
