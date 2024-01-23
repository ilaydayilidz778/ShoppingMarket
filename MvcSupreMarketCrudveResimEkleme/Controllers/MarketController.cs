using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcSupreMarketCrudveResimEkleme.Data.Class;
using MvcSupreMarketCrudveResimEkleme.Data.Context;
using MvcSupreMarketCrudveResimEkleme.Models;
using System.Xml.Serialization;

namespace MvcSupreMarketCrudveResimEkleme.Controllers
{
    public class MarketController : Controller
    {
        private readonly UygulamaDbContext _db;

        public MarketController(UygulamaDbContext db)
        {
            _db = db;
        }
        public IActionResult Listele()
        {
            var urunlerListesi = _db.urunler
                  .Include(u => u.Kategori)
                  .Include(u => u.Resim)
                  .ToList();

            return View(urunlerListesi);
        }

        public IActionResult Ekle()
        {
            ViewBag.Kategoriler = _db.kategoriler.Select(k => new SelectListItem(k.Ad, k.Id.ToString())).ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(ResimUrunViewModel model)
        {
            // Submit ile formdan gelen ResimUrunVewModelNesnesini Yakalayarak Özelliklerini Ürün Nesnesine Aktararak
            // Vertabanına kaydedeceğiz.
            try
            {
                ViewBag.Kategoriler = _db.kategoriler.Select(k => new SelectListItem(k.Ad, k.Id.ToString())).ToList();
                Urun yeniUrun = new Urun();
                Resim yeniResim = new Resim();
                if (_db.urunler.Any(u => u.Ad == model.Ad))
                {
                    TempData["Durum"] = "Eklemek istediğiniz ürün biligilerine sahip bir ürün zaten veri tabanında mevcuttur.";
                }
                if (model.Resim != null)
                {

                    // Eklenen resim dosyasının adı
                    var eklenenDosyaAdi = model.Resim.FileName;

                    // Eklenen resim dosyasının kaydedileceği dosya yolu 
                    var resminKaydedildigiDosyaYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", eklenenDosyaAdi);
                    // Dosya için bir akış ortamı oluşturalım
                    using (var fileStream = new FileStream(resminKaydedildigiDosyaYolu, FileMode.Create))
                    {
                        // Resmi oluşturduğumuz klasöre kopyalayalım.
                        model.Resim.CopyTo(fileStream);
                    }

                    // Eklenen resim dosyasının boyutu
                    // Kulllanmıyorum Öğrenmek Amaçlı Aldım.
                    var dosyaBoyutu = model.Resim.Length;

                    int uzanti = eklenenDosyaAdi.IndexOf(".");
                    if (uzanti != -1)
                    {
                        yeniResim.DosyaTipi = eklenenDosyaAdi.Substring(uzanti + 1);
                    }
                    yeniResim.DosyaYolu = eklenenDosyaAdi;
                    yeniResim.UrunId = model.Id;

                }

                // Automapper ile otomatik olarak propertyler eşleştirilebilir.
                if (ModelState.IsValid)
                {
                    yeniUrun.Id = model.Id;
                    yeniUrun.Ad = model.Ad;
                    yeniUrun.Fiyat = model.Fiyat;
                    yeniUrun.StotkataMi = model.StotkataMi;
                    yeniUrun.StokMiktari = model.StokMiktari;
                    yeniUrun.Resim = yeniResim;
                    yeniUrun.KategoriId = model.SeciliKategoriId;
                    // Veritabanına Kaydet
                    _db.urunler.Add(yeniUrun);
                    _db.SaveChanges();
                    return RedirectToAction("Listele");
                }
            }
            catch (Exception ex)
            {
                TempData["Durum"] = "Hata Oluştu!" + ex.Message;
            }
            return View(model);
        }
        public IActionResult Sil(int id)
        {

            var urunlerListesi = _db.urunler
                  .Include(u => u.Kategori)
                  .Include(u => u.Resim)
                  .ToList();
            Urun silinecekUrun = urunlerListesi.Find(u => u.Id == id);
            if (silinecekUrun == null)
            {
                return NotFound();
            }
            return View(silinecekUrun);
        }
        [HttpPost]
        public IActionResult Sil(Urun urun)
        {
            _db.urunler.Remove(urun);
            _db.SaveChanges();
            return RedirectToAction("Listele");
        }
        public IActionResult Guncelle(int id)
        {
            // Bilgilerieni güncellemek için seçtiğimiz ürünün tüm propertylerini Viewmodelden ürettiğimiz
            // model'e aktarırr ve Viewe aktarılmasını sağlarız.
            var urunlerListesi = _db.urunler
                  .Include(u => u.Kategori)
                  .Include(u => u.Resim)
                  .ToList();
            Urun guncellenecekUrun = urunlerListesi.Find(u => u.Id == id)!;
            TempData["Id"] = guncellenecekUrun.Id;
            if (guncellenecekUrun == null)
            {
                return NotFound();
            }

            ResimUrunViewModel model = new ResimUrunViewModel();
            model.Id = guncellenecekUrun.Id;
            model.Ad = guncellenecekUrun.Ad;
            model.Fiyat = guncellenecekUrun.Fiyat;
            model.StotkataMi = guncellenecekUrun.StotkataMi;
            model.StokMiktari = guncellenecekUrun.StokMiktari;

            return View(model);
        }

        [HttpPost]
        public IActionResult Guncelle(ResimUrunViewModel model)
        {
            try
            {
                var urunlerListesi = _db.urunler
                .Include(u => u.Kategori)
                .Include(u => u.Resim)
                .ToList();
                if (TempData["Id"] is int id)
                {
                    Urun guncellenecekUrun = urunlerListesi.Find(u => u.Id == id)!;
                    Resim yeniResim = new Resim();
                    if (guncellenecekUrun == null)
                    {
                        return NotFound();
                    }
                    if (_db.urunler.Any(u => u.Ad == model.Ad && u.Id != guncellenecekUrun.Id))
                    {
                        TempData["Durum"] = "Güncellemek istediğiniz ürün biligilerine sahip bir ürün zaten veri tabanında mevcuttur.";
                    }
                    if(model.Resim != null)
                    {
                        // Eklenen resmin dosya adı
                        var eklenenDosyaAdi = model.Resim.FileName;
                        var eklenenDosyaBoyutu = model.Resim.Length;

                        var resminKaydedildigiDosyaYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images" ,eklenenDosyaAdi);
                        using (var fileStream = new FileStream(resminKaydedildigiDosyaYolu, FileMode.Create ))
                        {
                            model.Resim.CopyTo(fileStream);
                        }
                        int indeks = eklenenDosyaAdi.IndexOf(".");
                        if (indeks != -1)
                        {
                            yeniResim.DosyaTipi =eklenenDosyaAdi.Substring(indeks);
                        }
                        yeniResim.DosyaYolu = eklenenDosyaAdi;
                        yeniResim.UrunId = id;
                    }
                    if (ModelState.IsValid)
                    {

                    }
                }
                return RedirectToAction("Listele");
            }
            catch (Exception ex)
            {
                TempData["Durum"] = "Hata Oluştu!" + ex.Message;
                return View(model);
            }
        }

    }
}
