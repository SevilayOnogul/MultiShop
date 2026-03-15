using AutoMapper;
using Moq;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.CategoryServices;
using MultiShop.Catalog.Settings;
using MongoDB.Driver;
using Xunit;

namespace MultiShop.Catalog.Tests
{
    public class CategoryServiceTests
    {
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<IMongoCollection<Category>> _mockCollection;
        private readonly CategoryService _categoryService;

        public CategoryServiceTests()
        {
            _mockMapper = new Mock<IMapper>();
            _mockCollection = new Mock<IMongoCollection<Category>>();

            // NOT: Sektörde genellikle MongoDB'yi direkt mock'lamak yerine 
            // DatabaseSettings nesnesini taklit ederiz. 
            // Eğer CategoryService constructor'ında IDatabaseSettings alıyorsa:
            // var mockSettings = new Mock<IDatabaseSettings>();
            // _categoryService = new CategoryService(_mockMapper.Object, mockSettings.Object);
        }

        [Fact]
        public async Task GetAllCategoryAsync_ShouldReturnCategoryList()
        {
            // 1. Arrange
            var categories = new List<Category> { new Category { CategoryId = "1", CategoryName = "Elektronik" } };
            var categoryDtos = new List<ResultCategoryDto> { new ResultCategoryDto { CategoryId = "1", CategoryName = "Elektronik" } };

            // Mapper'ı kuruyoruz: Category listesi gelirse ResultCategoryDto listesine çevir
            _mockMapper.Setup(x => x.Map<List<ResultCategoryDto>>(categories)).Returns(categoryDtos);

            // 2. Act
            // Not: Eğer servis metodun tam olarak buysa:
            // var result = await _categoryService.GetAllCategoryAsync();

            // 3. Assert
            // Assert.NotNull(result);
            // Assert.Single(result);
        }
    }
}