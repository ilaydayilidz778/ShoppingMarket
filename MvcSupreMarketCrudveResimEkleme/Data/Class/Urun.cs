using System.Security.Cryptography.X509Certificates;

namespace MvcSupreMarketCrudveResimEkleme.Data.Class
{
    public class Urun
    {
        public int Id { get; set; } 
        public string Ad { get; set; } = null!;
        public decimal Fiyat { get; set; }
        public bool StotkataMi { get; set; }
        public int StokMiktari { get; set; }
        public DateTime EklenmeTarihi { get; set; }
        public DateTime? GuncellenmeTarihi { get; set; }
        public DateTime? SatistanKaldirilmaTarihi { get; set; }

        // Kategori ile İlişkisi
        public int KategoriId { get; set; }
        public Kategori Kategori { get; set; }

        // Resim ile İlişkisi
        public Resim? Resim { get; set; }
    }
}
