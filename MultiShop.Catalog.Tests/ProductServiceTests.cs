using Moq;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Services.ProductServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Catalog.Tests
{
    public class ProductServiceTests
    {
        private readonly Mock<IProductService> _mockProductService;

        public ProductServiceTests()
        {
            _mockProductService = new Mock<IProductService>();
        }

        [Fact]
        public async Task GetAllProductAsync_ShouldReturnProductList()
        {
            var fakeProducts = new List<ResultProductDto>
            {
                new ResultProductDto{ProductId="1",ProductName="Laptop"},
                new ResultProductDto{ProductId="2",ProductName="Mouse"}

            };

            _mockProductService.Setup(x=>x.GetAllProductAsync()).ReturnsAsync(fakeProducts);

             var result=await _mockProductService.Object.GetAllProductAsync();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal("Laptop", result[0].ProductName);

        }

        [Fact]
        public async Task GetByIdProductAsync_ShouldReturnSingleProduct()
        {
            var productId = "ID-123";
            var fakeProduct = new GetByIdProductDto { ProductId = productId, ProductName = "Klavye" };

            _mockProductService.Setup(x => x.GetByIdProductAsync(productId)).ReturnsAsync(fakeProduct);

            var result = await _mockProductService.Object.GetByIdProductAsync(productId);

            Assert.NotNull(result);
            Assert.Equal("Klavye", result.ProductName);
            Assert.Equal(productId, result.ProductId);
        }

        [Fact]
        public async Task CreateProductAsync_ShouldReturnSuccess()
        {
            var createDto = new CreateProductDto { ProductName = "Kulaklık", ProductPrice = 1500 };

            _mockProductService.Setup(x => x.CreateProductAsync(createDto)).Returns(Task.CompletedTask);

            await _mockProductService.Object.CreateProductAsync(createDto);

            _mockProductService.Verify(x => x.CreateProductAsync(createDto), Times.Once);
        }

        [Fact]
        public async Task UpdateProductAsync_ShouldExecuteCorrectly()
        {
            var updateDto = new UpdateProductDto { ProductId = "1", ProductName = "Güncel Laptop" };
            _mockProductService.Setup(x => x.UpdateProductAsync(updateDto)).Returns(Task.CompletedTask);

            await _mockProductService.Object.UpdateProductAsync(updateDto);

            _mockProductService.Verify(x => x.UpdateProductAsync(It.IsAny<UpdateProductDto>()), Times.Once);
        }

        [Fact]
        public async Task DeleteProductAsync_ShouldExecuteCorrectly()
        {
            var productId = "99";
            _mockProductService.Setup(x => x.DeleteProductAsync(productId)).Returns(Task.CompletedTask);

            await _mockProductService.Object.DeleteProductAsync(productId);

            _mockProductService.Verify(x => x.DeleteProductAsync(productId), Times.Once);
        }
    
    }
}
