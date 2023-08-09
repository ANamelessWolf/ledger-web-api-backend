namespace Nameless.WebApi.Models
{

    /// <summary>
    /// OptionalOrderRequest
    /// </summary>
    public class OptionalOrderRequest
    {
        public string? orderField { get; set; }
        public OrderType orderType { get; set; }
        public OptionalOrderRequest()
        {
            this.orderType = OrderType.Asc;
        }
    }
}
