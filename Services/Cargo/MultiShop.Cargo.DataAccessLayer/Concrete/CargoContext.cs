using Microsoft.EntityFrameworkCore;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.DataAccessLayer.Concrete
{
    public class CargoContext : DbContext
    {
        // 1. BU YENİ CONSTRUCTOR'I EKLE:
        // Test projesi burayı kullanarak sana 'options' (test db adresi) gönderecek.
        public CargoContext(DbContextOptions<CargoContext> options) : base(options)
        {
        }

        // 2. BOŞ CONSTRUCTOR DURMALI:
        // Uygulama normal çalışırken veya Migration atarken bu lazım.
        public CargoContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // 3. KONTROL EKLE:
            // Eğer dışarıdan (testten) bir ayar gelmemişse, gerçek veritabanına bağlan.
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=localhost,1441;initial catalog=MultiShopCargoDb ; User=sa;Password=123456aA!;TrustServerCertificate=True");
            }
        }

        public DbSet<CargoCompany> CargoCompanies { get; set; }
        public DbSet<CargoDetail> CargoDetails { get; set; }
        public DbSet<CargoCustomer> CargoCustomers { get; set; }
        public DbSet<CargoOperation> CargoOperations { get; set; }
    }
}