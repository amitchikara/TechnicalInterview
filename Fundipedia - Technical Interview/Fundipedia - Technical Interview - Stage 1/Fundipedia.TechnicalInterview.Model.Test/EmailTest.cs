using Fundipedia.TechnicalInterview.Model.Supplier;
using System.ComponentModel.DataAnnotations;

namespace Fundipedia.TechnicalInterview.Model.Test
{
    public class EmailTest
    {
        [Test]
        public void When_EmailIsCreatedWithInvalidEmail_Then_ShouldFailValidationWithErrorMessage()
        {
            //Arrange
            var email = new Email()
            {
                IsPreferred = true,
                EmailAddress = "wrongemailAddress.com"
            };

            var context = new ValidationContext(email);
            var results = new List<ValidationResult>();

            //Act
            var isValid = Validator.TryValidateObject(email, context, results, true);

            //Assert
            Assert.IsFalse(isValid);
            Assert.AreEqual(results.First().ErrorMessage, "The EmailAddress field is not a valid e-mail address.");
        }

        [Test]
        public void When_EmailIsCreatedWithoutEmail_Then_ShouldFailValidationWithErrorMessage()
        {
            //Arrange
            var email = new Email()
            {
                IsPreferred = true,
                EmailAddress = null
            };

            var context = new ValidationContext(email);
            var results = new List<ValidationResult>();

            //Act
            var isValid = Validator.TryValidateObject(email, context, results, true);

            //Assert
            Assert.IsFalse(isValid);
            Assert.AreEqual(results.First().ErrorMessage, "The EmailAddress field is required.");
        }

        [Test]
        public void When_EmailIsCreatedWithoutError_Then_ShouldPassWithoutErrorMessage()
        {
            //Arrange
            var email = new Email()
            {
                IsPreferred = true,
                EmailAddress = "validemail@address.com"
            };

            var context = new ValidationContext(email);
            var results = new List<ValidationResult>();

            //Act
            var isValid = Validator.TryValidateObject(email, context, results, true);

            //Assert
            Assert.IsTrue(isValid);
            Assert.AreEqual(0,results.Count);
        }
    }
}
