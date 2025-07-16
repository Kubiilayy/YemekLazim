using BitirmeProjesiDeneme2.Models;
using BitirmeProjesiDeneme2.Utility;
using Microsoft.AspNetCore.Mvc;

namespace BitirmeProjesiDeneme2.Controllers
{
    public class AdminTarifController : Controller
    {
        private readonly UygulamaDbContext _context;

        public AdminTarifController(UygulamaDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var tarifler = _context.Tarifler.ToList();
            return View(tarifler);
        }

        [HttpGet]
        public ActionResult TarifEkle()
        {
            // Tüm malzemeleri listelemek için Malzeme listesini ViewBag'e atıyoruz
            ViewBag.Malzemeler = _context.Malzemeler.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult TarifEkle(Tarif t, List<int> selectedMalzemeler)
        {
            _context.Tarifler.Add(t);
            _context.SaveChanges();

            // Seçilen malzemeler ile ilişkileri TarifMalzeme tablosuna ekle
            foreach (var malzemeId in selectedMalzemeler)
            {
                var tarifMalzeme = new TarifMalzeme
                {
                    TarifId = t.Id,
                    MalzemeId = malzemeId
                };
                _context.TarifMalzemeleri.Add(tarifMalzeme);
            }
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult TarifSil(int id)
        {
            var tarif = _context.Tarifler.Find(id);
            _context.Tarifler.Remove(tarif);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult TarifGuncelle(int id)
        {
            var tarif = _context.Tarifler.Find(id);
            ViewBag.Malzemeler = _context.Malzemeler.ToList();
            ViewBag.SelectedMalzemeler = _context.TarifMalzemeleri
                .Where(tm => tm.TarifId == id)
                .Select(tm => tm.MalzemeId)
                .ToList();
            return View(tarif);
        }

        [HttpPost]
        public ActionResult TarifGuncelle(Tarif t, List<int> selectedMalzemeIds)
        {
            var tarif = _context.Tarifler.Find(t.Id);
            tarif.Ad = t.Ad;
            tarif.Açıklama = t.Açıklama;
            _context.SaveChanges();

            // Eski malzemeleri sil
            var eskiMalzemeler = _context.TarifMalzemeleri.Where(tm => tm.TarifId == t.Id).ToList();
            _context.TarifMalzemeleri.RemoveRange(eskiMalzemeler);
            _context.SaveChanges();

            // Seçilen yeni malzemeleri ekle
            if (selectedMalzemeIds != null)
            {
                foreach (var malzemeId in selectedMalzemeIds)
                {
                    var tarifMalzeme = new TarifMalzeme
                    {
                        TarifId = t.Id,
                        MalzemeId = malzemeId
                    };
                    _context.TarifMalzemeleri.Add(tarifMalzeme);
                }
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
