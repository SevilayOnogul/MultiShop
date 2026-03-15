using Microsoft.EntityFrameworkCore;
using MultiShop.Cargo.DataAccessLayer.Concrete;
using MultiShop.Cargo.EntityLayer.Concrete;
using Xunit;

namespace MultiShop.Cargo.Tests
{
    public class CargoIntegrationTests
    {
        // 1. Ayarları yapılandırıyoruz
        private DbContextOptions<CargoContext> GetOptions()
        {
            // SENİN BİLGİLERİNE GÖRE AYARLANDI:
            // Port: 1441, Password: senin belirttiğin şifre
            // Database ismini karışmaması için sonuna '_Test' ekledik.
            var connectionString = @"Server=localhost,1441;Database=MultiShopCargoDb_Test;User Id=sa;Password=123456aA!;TrustServerCertificate=True";

            return new DbContextOptionsBuilder<CargoContext>()
                .UseSqlServer(connectionString)
                .Options;
        }

        [Fact]
        public async Task CreateCargoCompany_ShouldSaveToDatabase()
        {
            // 2. Arrange (Hazırlık)
            var options = GetOptions();

            // Yeni oluşturduğumuz constructor sayesinde artık 'options' gönderebiliyoruz.
            using (var context = new CargoContext(options))
            {
                // Test veritabanının ve tabloların Docker üzerinde oluştuğundan emin oluyoruz.
                await context.Database.EnsureCreatedAsync();

                var company = new CargoCompany
                {
                    CargoCompanyName = "Aras Kargo"
                };

                // 3. Act (Eylem)
                context.CargoCompanies.Add(company);
                await context.SaveChangesAsync();

                // 4. Assert (Doğrulama)
                // Veriyi gerçekten veritabanından geri çekiyoruz.
                var savedCompany = await context.CargoCompanies
                    .FirstOrDefaultAsync(x => x.CargoCompanyName == "Aras Kargo");

                Assert.NotNull(savedCompany);
                Assert.Equal("Aras Kargo", savedCompany.CargoCompanyName);

                // 5. Cleanup (Temizlik)
                // Test bittikten sonra arkamızda çöp bırakmıyoruz.
                context.CargoCompanies.Remove(savedCompany);
                await context.SaveChangesAsync();
            }
        }
    }
}