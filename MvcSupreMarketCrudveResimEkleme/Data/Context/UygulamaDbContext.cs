using Microsoft.EntityFrameworkCore;
using MvcSupreMarketCrudveResimEkleme.Data.Class;

namespace MvcSupreMarketCrudveResimEkleme.Data.Context
{
    public class UygulamaDbContext : DbContext
    {
        public UygulamaDbContext(DbContextOptions<UygulamaDbContext> options) : base(options)
        {
        }
        public DbSet<Kategori> kategoriler { get; set; }
        public DbSet<Urun> urunler { get; set; }
        public DbSet<Resim> resimler { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kategori>().HasData(
                new Kategori() { Id = 1, Ad = "Su & İçecek" },
                new Kategori() { Id = 2, Ad = "Meyve & Sebze" },
                new Kategori() { Id = 3, Ad = "Süt Ürünleri" },
                new Kategori() { Id = 4, Ad = "Atıştırmalık" },
                new Kategori() { Id = 5, Ad = "Temel Gıda" },
                new Kategori() { Id = 6, Ad = "Kahvaltılık" },
                new Kategori() { Id = 7, Ad = "Fırından" },
                new Kategori() { Id = 8, Ad = "Kişisel Bakım" },
                new Kategori() { Id = 9, Ad = "Evcil Hayvan" },
                new Kategori() { Id = 10, Ad = "Ev Bakım" }
                );
        }
    }
}
