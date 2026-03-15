using Moq;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommand;
using MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Tests
{
    public class CreateOrderingCommandHandlerTests
    {
        private readonly Mock<IRepository<Ordering>> _mockRepository;
        private readonly CreateOrderingCommandHandler _handler;

        public CreateOrderingCommandHandlerTests()
        {
            _mockRepository = new Mock<IRepository<Ordering>>();

            _handler = new CreateOrderingCommandHandler(_mockRepository.Object);
        }

        [Fact]
        public async Task Handle_ShouldCreateOrdering_WhenCommandIsValid()
        {
            var command = new CreateOrderingCommand
            {
                UserId = "user-123",
                TotalPrice = 100
            };

            await _handler.Handle(command, CancellationToken.None);

       
            _mockRepository.Verify(x => x.CreateAsync(It.IsAny<Ordering>()), Times.Once);
        }
    }
}