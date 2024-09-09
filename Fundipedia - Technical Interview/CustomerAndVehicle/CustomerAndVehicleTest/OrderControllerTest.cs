using CustomerAndVehicle.Controllers;
using CustomerAndVehicleDomain;
using CustomerAndVehicleModel;

namespace CustomerAndVehicleTest
{
    public class OrderControllerTest
    {
        private readonly OrderController _controller;

        public OrderControllerTest()
        {
            _controller = new OrderController(new OrderService());
        }

        /// <summary>
        /// Large repair orders for new customers should be closed.
        /// </summary>
        [Test]
        public void When_LargeRepairOrderAndNewCustomer_Then_StatusIsClosed()
        {
            // Arrange
            OrderRequest orderRequest = new OrderRequest()
            {
                IsLargeOrder = true,
                IsNewCustomer = true,
                IsRushOrder =   false,
                OrderType = OrderType.Repair
            };

            // Act
            var result = _controller.ProcessOrder(orderRequest);

            // Assert
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)result.Result).Value, OrderStatus.Closed);
        }

        /// <summary>
        /// Large rush hire orders should always be closed.
        /// </summary>
        [Test]
        public void When_LargeRushHireOrder_Then_StatusIsClosed()
        {
            // Arrange
            OrderRequest orderRequest = new OrderRequest()
            {
                IsLargeOrder = true,
                IsNewCustomer = false,
                IsRushOrder = true,
                OrderType = OrderType.Hire
            };

            // Act
            var result = _controller.ProcessOrder(orderRequest);

            // Assert
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)result.Result).Value, OrderStatus.Closed);
        }

        /// <summary>
        /// Large repair orders always require authorisation
        /// </summary>
        [Test]
        public void When_LargeRepairOrder_Then_StatusIsAuthorisation()
        {
            // Arrange
            OrderRequest orderRequest = new OrderRequest()
            {
                IsLargeOrder = true,
                IsNewCustomer = false,
                IsRushOrder = false,
                OrderType = OrderType.Repair
            };

            // Act
            var result = _controller.ProcessOrder(orderRequest);

            // Assert
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)result.Result).Value, OrderStatus.AuthorisationRequired);
        }

        /// <summary>
        /// All rush orders for new customers always require authorisation.
        /// </summary>
        [Test]
        public void When_RushRepairOrderAndNewCustomer_Then_StatusIsAuthorisation()
        {
            // Arrange
            OrderRequest orderRequest = new OrderRequest()
            {
                IsLargeOrder = false,
                IsNewCustomer = true,
                IsRushOrder = true,
                OrderType = OrderType.Repair
            };

            // Act
            var result = _controller.ProcessOrder(orderRequest);

            // Assert
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)result.Result).Value, OrderStatus.AuthorisationRequired);
        }

        /// <summary>
        /// All rush orders for new customers always require authorisation.
        /// </summary>
        [Test]
        public void When_RushHireOrderAndNewCustomer_Then_StatusIsAuthorisation()
        {
            // Arrange
            OrderRequest orderRequest = new OrderRequest()
            {
                IsLargeOrder = false,
                IsNewCustomer = true,
                IsRushOrder = true,
                OrderType = OrderType.Hire
            };

            // Act
            var result = _controller.ProcessOrder(orderRequest);

            // Assert
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)result.Result).Value, OrderStatus.AuthorisationRequired);
        }

        /// <summary>
        /// All other orders should be confirmed.
        /// </summary>
        [Test]
        public void When_HireOtherOrder_Then_StatusIsConfirmed()
        {
            // Arrange
            OrderRequest orderRequest = new OrderRequest()
            {
                IsLargeOrder = false,
                IsNewCustomer = false,
                IsRushOrder = true,
                OrderType = OrderType.Hire
            };

            // Act
            var result = _controller.ProcessOrder(orderRequest);

            // Assert
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)result.Result).Value, OrderStatus.Confirmed);
        }

        /// <summary>
        /// All other orders should be confirmed.
        /// </summary>
        [Test]
        public void When_RepairOtherOrder_Then_StatusIsConfirmed()
        {
            // Arrange
            OrderRequest orderRequest = new OrderRequest()
            {
                IsLargeOrder = false,
                IsNewCustomer = false,
                IsRushOrder = true,
                OrderType = OrderType.Repair
            };

            // Act
            var result = _controller.ProcessOrder(orderRequest);

            // Assert
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)result.Result).Value, OrderStatus.Confirmed);
        }
    }
}