namespace MvcSupreMarketCrudveResimEkleme.Data.Class
{
    public class Resim
    {
        public int Id { get; set; }
        public string DosyaTipi { get; set; } = null!;
        public string DosyaYolu { get; set; } = null!;

        // Urun ile iliskisini kuralım
        public int UrunId { get; set; }
        public Urun Urun { get; set; }
    }
}
