using Moq;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.BusinessLayer.Concrete;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;
using Xunit;

namespace MultiShop.Cargo.Tests
{
    public class CargoCustomerManagerTests
    {
        private readonly Mock<ICargoCustomerDal> _mockCustomerDal;
        private readonly CargoCustomerManager _customerManager;

        public CargoCustomerManagerTests()
        {
            _mockCustomerDal = new Mock<ICargoCustomerDal>();
            _customerManager = new CargoCustomerManager(_mockCustomerDal.Object);
        }

        [Fact]
        public void TGetById_ShouldReturnCustomer_WhenIdIsValid()
        {
            // 1. Arrange
            var customerId = 1;
            var fakeCustomer = new CargoCustomer { CargoCustomerId = customerId, Name = "Ahmet", Surname = "Yılmaz" };
            _mockCustomerDal.Setup(x => x.GetById(customerId)).Returns(fakeCustomer);

            // 2. Act
            var result = _customerManager.TGetById(customerId);

            // 3. Assert
            Assert.NotNull(result);
            Assert.Equal("Ahmet", result.Name);
            _mockCustomerDal.Verify(x => x.GetById(customerId), Times.Once);
        }
    }
}