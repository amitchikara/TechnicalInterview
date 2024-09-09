namespace CustomerAndVehicleModel.Orders
{
    public class Order : IOrder
    {
        protected readonly OrderRequest _orderRequest;

        public Order(OrderRequest orderRequest)
        {
            _orderRequest = orderRequest;
        }

        public virtual OrderStatus DetermineOrderStatus()
        {
            return OrderStatus.Confirmed;
        }
    }
}
