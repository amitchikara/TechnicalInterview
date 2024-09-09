namespace CustomerAndVehicleModel.Orders
{
    public class RepairOrder : Order
    {
        public RepairOrder(OrderRequest orderRequest):base(orderRequest)
        {

        }

        public override OrderStatus DetermineOrderStatus()
        {
            if (_orderRequest.IsLargeOrder && _orderRequest.IsNewCustomer)
            {
                return OrderStatus.Closed;
            }

            if (_orderRequest.IsLargeOrder)
            {
                return OrderStatus.AuthorisationRequired;
            }

            if (_orderRequest.IsRushOrder && _orderRequest.IsNewCustomer)
            {
                return OrderStatus.AuthorisationRequired;
            }

            return base.DetermineOrderStatus();
        }
    }
}
