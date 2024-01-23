namespace MvcSupreMarketCrudveResimEkleme.Data.Class
{
    public class Kategori
    {
        public int Id { get; set; }
        public string Ad { get; set; }

        // Urun ile ilişkisi
        public ICollection<Urun>? Urunler { get; set; }
    }
}
