using CustomerAndVehicleModel;
using CustomerAndVehicleModel.Orders;

namespace CustomerAndVehicleDomain
{
    public interface IOrderService
    {
        IOrder ProcessOrder(OrderRequest orderRequest);
    }
}