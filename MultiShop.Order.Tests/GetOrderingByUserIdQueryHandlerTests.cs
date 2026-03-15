using Moq;
using MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Tests
{
    public class GetOrderingByUserIdQueryHandlerTests
    {
        private readonly Mock<IOrderingRepository> _mockRepository;
        private readonly GetOrderingByUserIdQueryHandler _handler;

        public GetOrderingByUserIdQueryHandlerTests()
        {
            // Bu sefer IOrderingRepository kullanıyoruz çünkü Handler bunu bekliyor
            _mockRepository = new Mock<IOrderingRepository>();
            _handler = new GetOrderingByUserIdQueryHandler(_mockRepository.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnOrderingList_WhenUserIdIsValid()
        {
            // 1. Arrange (Hazırlık)
            var userId = "user-777";
            var query = new GetOrderingByUserIdQuery(userId);

            // Sahte verimizi hazırlıyoruz (Veritabanından geliyormuş gibi)
            var fakeData = new List<Ordering>
            {
                new Ordering { OrderingId = 1, UserId = userId, TotalPrice = 1250 },
                new Ordering { OrderingId = 2, UserId = userId, TotalPrice = 2500 }
            };

            // Repo metodunu taklit ediyoruz (Senkron olduğu için .Returns kullandık)
            _mockRepository.Setup(x => x.GetOrderingsByUserId(userId)).Returns(fakeData);

            // 2. Act (Çalıştırma)
            var result = await _handler.Handle(query, CancellationToken.None);

            // 3. Assert (Doğrulama)
            Assert.NotNull(result); // Sonuç boş olmamalı
            Assert.Equal(2, result.Count); // 2 tane sipariş dönmeli
            Assert.Equal(userId, result[0].UserId); // Gelen veri doğru kullanıcıya mı ait?

            // Davranış kontrolü
            _mockRepository.Verify(x => x.GetOrderingsByUserId(userId), Times.Once);
        }
    }
}

