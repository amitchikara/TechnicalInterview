using Fundipedia.TechnicalInterview.Model.Extensions;

namespace Fundipedia.TechnicalInterview.Model.Test
{
    public class SupplierExtensionsTest
    {
        [Test]
        public void When_ActivationDateIsNull_Then_IsActiveMustBeFalse()
        {
            //Arrange
            Supplier.Supplier supplier = new Supplier.Supplier()
            {
                ActivationDate = null
            };


            //Act
            var isActive = supplier.IsActive();

            //Assert
            Assert.IsFalse(isActive);
        }

        [Test]
        public void When_ActivationDateIsNotNull_Then_IsActiveMustBeTrue()
        {
            //Arrange
            Supplier.Supplier supplier = new Supplier.Supplier()
            {
                ActivationDate = new DateTime(2024, 9, 7)
            };


            //Act
            var isActive = supplier.IsActive();

            //Assert
            Assert.IsTrue(isActive);
        }
    }
}