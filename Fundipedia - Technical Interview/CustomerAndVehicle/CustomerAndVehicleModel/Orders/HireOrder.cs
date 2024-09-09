namespace CustomerAndVehicleModel.Orders
{
    public class HireOrder : Order
    {
        public HireOrder(OrderRequest orderRequest) : base(orderRequest)
        {
        }

        public override OrderStatus DetermineOrderStatus()
        {
            if (_orderRequest.IsRushOrder && _orderRequest.IsLargeOrder)
            {
                return OrderStatus.Closed;
            }

            if (_orderRequest.IsRushOrder && _orderRequest.IsNewCustomer)
            {
                return OrderStatus.AuthorisationRequired;
            }

            return base.DetermineOrderStatus();
        }
    }
}
