using MvcSupreMarketCrudveResimEkleme.Data.Class;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace MvcSupreMarketCrudveResimEkleme.Models
{
    public class ResimUrunViewModel
    {
     
        public int Id { get; set; }

        [Required(ErrorMessage = "Ad Alanı Zorunludur.")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Fiyat Alanı Zorunludur.")]
        [Range(0, 10000, ErrorMessage = "Fiyat 0 ile {1} arasında olmalıdır.")]
        public decimal Fiyat { get; set; }
        public bool StotkataMi { get; set; }
        [Required(ErrorMessage = "Stok Miktarı Belirtmek Zorunludur.")]
        public int StokMiktari { get; set; }

        [Required(ErrorMessage = "Kategori seçimi zorunludur.")]
        public int SeciliKategoriId { get; set; }


        public IFormFile? Resim { get; set; } // Ürün Görselinin Resmini Eklemk Opsiyoneldir. Bu Yüzden Nullable OlaraK Belirledik.
    }
}
