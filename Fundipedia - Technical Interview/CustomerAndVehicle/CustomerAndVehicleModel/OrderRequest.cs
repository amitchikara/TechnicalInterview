namespace CustomerAndVehicleModel
{
    public class OrderRequest
    {
        public bool IsRushOrder { get; set; }
        public OrderType OrderType { get; set; }
        public bool IsNewCustomer { get; set; }
        public bool IsLargeOrder { get; set; }
    }
}