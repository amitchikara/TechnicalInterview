using Microsoft.AspNetCore.Mvc;
using CustomerAndVehicleModel;
using CustomerAndVehicleDomain;

namespace CustomerAndVehicle.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("process-order")]
        public ActionResult<OrderStatus> ProcessOrder([FromBody] OrderRequest orderRequest)
        {
            var order = _orderService
                            .ProcessOrder(orderRequest)
                            .DetermineOrderStatus();
            
            return Ok(order);
        }
    }

}
