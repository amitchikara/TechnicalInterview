using Fundipedia.TechnicalInterview.Model.Supplier;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace Fundipedia.TechnicalInterview.Model.Test
{
    public class SupplierTest
    {
        [Test]
        public void When_SupplierIsCreatedWithValidValues_Then_NoErrors()
        {
            //Arrange
            Supplier.Supplier supplier = new Supplier.Supplier()
            {
                Id = Guid.NewGuid(),
                Title = "Mr.",
                FirstName = "Tony",
                LastName = "Stark",
                ActivationDate = DateTime.Today.AddDays(1)
            };

            var context = new ValidationContext(supplier);
            var results = new List<ValidationResult>();

            //Act
            var isValid = Validator.TryValidateObject(supplier, context, results, true);

            //Assert
            Assert.IsTrue(isValid);
        }

        [Test]
        public void When_SupplierIsCreatedWithTodaysDate_Then_ShouldFailValidationWithErrorMessage()
        {
            //Arrange
            Supplier.Supplier supplier = new Supplier.Supplier()
            {
                Id = Guid.NewGuid(),
                Title = "Mr.",
                FirstName = "Tony",
                LastName = "Stark",
                ActivationDate = DateTime.Today
            };

            var context = new ValidationContext(supplier);
            var results = new List<ValidationResult>();

            //Act
            var isValid = Validator.TryValidateObject(supplier, context, results, true);

            //Assert
            Assert.IsFalse(isValid);
            Assert.AreEqual(results.First().ErrorMessage, "Activation date must be tomorrow or later.");
        }

        [Test]
        public void When_SupplierIsCreatedWithFutureDate_Then_ShouldPassValidationWithoutErrorMessage()
        {
            //Arrange
            Supplier.Supplier supplier = new Supplier.Supplier()
            {
                Id = Guid.NewGuid(),
                Title = "Mr.",
                LastName = "Stark",
                ActivationDate = DateTime.Today.AddDays(1)
            };

            var context = new ValidationContext(supplier);
            var results = new List<ValidationResult>();

            //Act
            var isValid = Validator.TryValidateObject(supplier, context, results, true);

            //Assert
            Assert.IsTrue(isValid);
        }
    }
}
