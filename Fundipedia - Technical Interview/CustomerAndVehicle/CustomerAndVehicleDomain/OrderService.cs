using CustomerAndVehicleModel;
using CustomerAndVehicleModel.Orders;

namespace CustomerAndVehicleDomain
{
    public class OrderService : IOrderService
    {
        public IOrder ProcessOrder(OrderRequest orderRequest)
        {
            return orderRequest.OrderType switch
            {
                OrderType.Hire => new HireOrder(orderRequest),
                OrderType.Repair => new RepairOrder(orderRequest),
            };
        }
    }
}
