using Fundipedia.TechnicalInterview.Controllers;
using Fundipedia.TechnicalInterview.Domain;
using Fundipedia.TechnicalInterview.Model.Supplier;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Fundipedia.TechnicalInterviewTest
{
    public class SuppliersControllerTest
    {
        private readonly Mock<ISupplierService> _mockService;
        private readonly SuppliersController _controller;

        public SuppliersControllerTest()
        {
            _mockService = new Mock<ISupplierService>();
            _controller = new SuppliersController(_mockService.Object);
        }

        [Test]
        public async Task GetSupplier_ReturnsOkResult_WhenSupplierExists()
        {
            // Arrange
            var testGuid = Guid.NewGuid();
            var testSupplier = new Supplier { Id = testGuid, FirstName = "Peter Parker" };

            _mockService.Setup(service => service.GetSupplier(testGuid))
                        .ReturnsAsync(testSupplier);

            // Act
            var result = await _controller.GetSupplier(testGuid);

            // Assert
            Assert.IsInstanceOf<ActionResult<Supplier>>(result);
            Assert.IsInstanceOf<Supplier>(result.Value);
            Assert.AreEqual(testSupplier.Id, result.Value.Id);
            Assert.AreEqual(testSupplier.FirstName, result.Value.FirstName);
        }

        [Test]
        public async Task GetSupplier_ReturnsNotFound_WhenSupplierDoesNotExist()
        {
            // Arrange
            var testGuid = Guid.NewGuid();

            _mockService.Setup(service => service.GetSupplier(testGuid))
                        .ReturnsAsync((Supplier)null);

            // Act
            var result = await _controller.GetSupplier(testGuid);

            // Assert
            Assert.IsInstanceOf<ActionResult<Supplier>>(result);
            Assert.IsNull(result.Value);
        }

        [Test]
        public async Task GetSuppliers_ReturnsOkResult_WhenSuppliersExists()
        {
            // Arrange
            var testGuid1 = Guid.NewGuid();
            var testGuid2 = Guid.NewGuid();

            List<Supplier> suppliers = new List<Supplier>()
            {
                new Supplier { Id = testGuid1, FirstName = "Peter Parker" },
                new Supplier { Id = testGuid2, FirstName = "Tony Stark" }
            };

            _mockService.Setup(service => service.GetSuppliers())
                        .ReturnsAsync(suppliers);

            // Act
            var result = await _controller.GetSupplier();

            // Assert
            Assert.IsInstanceOf<ActionResult<IEnumerable<Supplier>>>(result);
            Assert.IsInstanceOf<List<Supplier>>(result.Value);
            Assert.AreEqual(2, result.Value.Count());
            Assert.AreEqual(result.Value.First().FirstName, "Peter Parker");
        }

        [Test]
        public async Task PostSupplier_ReturnsOkResult_WhenSupplierSaved()
        {
            // Arrange
            var testGuid = Guid.NewGuid();
            var testSupplier = new Supplier { Id = testGuid, FirstName = "Peter Parker" };

            // Act
            var result = await _controller.PostSupplier(testSupplier);

            // Assert
            Assert.IsInstanceOf<ActionResult<Supplier>>(result);
            Assert.AreEqual(((CreatedAtActionResult)result.Result).ActionName, "GetSupplier");
            Assert.AreEqual(((Supplier)((ObjectResult)result.Result).Value).FirstName, "Peter Parker");
        }

        [Test]
        public async Task DeleteSupplier_ReturnsOkResult_WhenSupplierSaved()
        {
            // Arrange
            var testGuid = Guid.NewGuid();
            var testSupplier = new Supplier { Id = testGuid, FirstName = "Peter Parker" };

            // Act
            await _controller.PostSupplier(testSupplier);
            var result = await _controller.DeleteSupplier(testGuid);

            // Assert
            Assert.IsInstanceOf<ActionResult<Supplier>>(result);
        }
    }
}