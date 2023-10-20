namespace Ramos.ShoppingCart.ApiRest.Shared.Models
{
    public class ResultDto<T>
    {
        //public TraceDto Trace { get; set; }

        public StatusDto Status { get; set; }

        public T Payload { get; set; }

        public ResultDto(T payload)
        {
            Payload = payload;
        }
    }
}
