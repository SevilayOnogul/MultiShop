using AutoMapper;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.CategoryServices;
using MultiShop.Catalog.Settings;
using Xunit;

namespace MultiShop.Catalog.Tests
{
    public class CategoryServiceIntegrationTests
    {
        private readonly ICategoryService _categoryService;
        private readonly IMongoCollection<Category> _categoryCollection;

        public CategoryServiceIntegrationTests()
        {
            // 1. Gerçek AutoMapper Yapılandırması
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                // Buraya projenizdeki Mapping profilini ekleyin
                // cfg.AddProfile<GeneralMapping>(); 
                cfg.AddProfile<MultiShop.Catalog.Mapping.GeneralMapping>();
            });
            var mapper = mapperConfig.CreateMapper();

            // 2. Gerçek MongoDB Bağlantısı (TEST VERİTABANI OLMALI)
            // Sektörde genellikle "MultiShopCatalogDb_Test" gibi ayrı bir DB kullanılır.
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("MultiShopCatalogDb_Test");
            _categoryCollection = database.GetCollection<Category>("Categories");

            // 3. Settings Mock'u (Sadece bağlantı bilgilerini taşır)
            var settings = Options.Create(new DatabaseSettings
            {
                CategoryCollectionName = "Categories",
                ConnectionString = "mongodb://localhost:27017",
                DatabaseName = "MultiShopCatalogDb_Test"
            });

            // Servisi gerçek nesnelerle ayağa kaldırıyoruz
            _categoryService = new CategoryService(mapper, settings.Value);
        }

        [Fact]
        public async Task CreateCategoryAsync_ShouldActuallyPersistToMongoDB()
        {
            // Arrange
            var dto = new CreateCategoryDto { CategoryName = "Test Kategorisi" };

            // Act: Gerçekten DB'ye yazma işlemi
            await _categoryService.CreateCategoryAsync(dto);

            // Assert: DB'ye gidip gerçekten orada mı diye kontrol et
            var savedCategory = await _categoryCollection
                .Find(x => x.CategoryName == "Test Kategorisi")
                .FirstOrDefaultAsync();

            Assert.NotNull(savedCategory);
            Assert.Equal("Test Kategorisi", savedCategory.CategoryName);

            // Cleanup: Test bittikten sonra DB'yi kirletmemek için temizlik yapıyoruz
            await _categoryCollection.DeleteOneAsync(x => x.CategoryId == savedCategory.CategoryId);
        }
    }
}