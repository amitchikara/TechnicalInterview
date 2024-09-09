using Fundipedia.TechnicalInterview.Model.Supplier;
using System.ComponentModel.DataAnnotations;

namespace Fundipedia.TechnicalInterview.Model.Test
{
    public class PhoneTest
    {
        [Test]
        public void When_PhoneIsCreatedWithInvalidNumber_Then_ShouldFailValidationWithErrorMessage()
        {
            //Arrange
            var phone = new Phone()
            {
                IsPreferred = true,
                PhoneNumber = "ABC123"
            };

            var context = new ValidationContext(phone);
            var results = new List<ValidationResult>();

            //Act
            var isValid = Validator.TryValidateObject(phone, context, results, true);

            //Assert
            Assert.IsFalse(isValid);
            Assert.AreEqual(results.First().ErrorMessage, "Phone number must be numbers only.");
        }

        [Test]
        public void When_PhoneIsValidButExceedTheLimit_Then_ShouldFailValidationWithErrorMessage()
        {
            //Arrange
            var phone = new Phone()
            {
                IsPreferred = true,
                PhoneNumber = "12345678910"
            };

            var context = new ValidationContext(phone);
            var results = new List<ValidationResult>();

            //Act
            var isValid = Validator.TryValidateObject(phone, context, results, true);

            //Assert
            Assert.IsFalse(isValid);
            Assert.AreEqual(results.First().ErrorMessage, "Phone number must not be more than 10 digits.");
        }

        [Test]
        public void When_PhoneIsCreatedWithoutError_Then_ShouldPassWithoutErrorMessage()
        {
            //Arrange
            var phone = new Phone()
            {
                IsPreferred = true,
                PhoneNumber = "123456"
            };

            var context = new ValidationContext(phone);
            var results = new List<ValidationResult>();

            //Act
            var isValid = Validator.TryValidateObject(phone, context, results, true);

            //Assert
            Assert.IsTrue(isValid);
            Assert.AreEqual(0, results.Count);
        }
    }
}
