using Ramos.ShoppingCart.ApiRest.Shared.Models;
using System.Net;

namespace Ramos.ShoppingCart.ApiRest.Shared.Helpers
{
    public class HelperStatus
    {
        public static ResultDto<T> ResponseHelper<T>(T payload/*, string traceId = ""*/, HttpStatusCode codEstado = HttpStatusCode.OK, string message = "")
        {
            return new ResultDto<T>(payload)
            {
                /*
                Trace = new TraceDto
                {
                    TraceId = traceId
                },
                */
                Status = new StatusDto
                {
                    HttpCode = codEstado,
                    Message = message
                }
            };
        }
    }
}
