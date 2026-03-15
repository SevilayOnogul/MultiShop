using Moq;
using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using Xunit;

namespace MultiShop.Order.Tests
{
    public class RemoveAddressCommandHandlerTests
    {
        private readonly Mock<IRepository<Address>> _mockRepository;
        private readonly RemoveAddressCommandHandler _handler;

        public RemoveAddressCommandHandlerTests()
        {
            _mockRepository = new Mock<IRepository<Address>>();
            _handler = new RemoveAddressCommandHandler(_mockRepository.Object);
        }

        [Fact]
        public async Task Handle_ShouldDeleteAddress_WhenIdIsValid()
        {
            // Arrange
            var addressId = 5;
            var command = new RemoveAddressCommand(addressId);

            // Act
            await _handler.Handle(command);

            // Assert
    
            _mockRepository.Verify(x => x.DeleteAsync(It.IsAny<Address>()), Times.Once);
        }
    }
}