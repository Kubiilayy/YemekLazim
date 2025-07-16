using BitirmeProjesiDeneme2.Models;
using BitirmeProjesiDeneme2.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BitirmeProjesiDeneme2.Controllers
{
    public class MalzemeController : Controller
    {
        private readonly UygulamaDbContext _context;

        public MalzemeController(UygulamaDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            var malzemeler = _context.Malzemeler.ToList();
            return View(malzemeler);
        }
        [HttpPost]
        public IActionResult FindRecipes(int[] selectedIngredients)
        {
            if (selectedIngredients == null || selectedIngredients.Length == 0)
            {
                ViewBag.EksikMalzemeBilgisi = "Lütfen en az bir malzeme seçin.";
                return View("FindRecipes", new List<(Tarif tarif, List<string> eksikler)>());
            }

            var tarifler = _context.Tarifler.Include(t => t.TarifMalzemeler).ToList();
            var uygunTarifler = new List<(Tarif tarif, List<string> eksikler)>();

            foreach (var tarif in tarifler)
            {
                var tarifMalzemeleri = tarif.TarifMalzemeler.Select(tm => tm.MalzemeId).ToList();


                var eksikler = tarifMalzemeleri.Except(selectedIngredients).ToList();
                var fazlaMalzemeler = selectedIngredients.Except(tarifMalzemeleri).ToList();


                if (selectedIngredients.All(si => !tarifMalzemeleri.Contains(si)))
                {
                    continue;
                }


                if (eksikler.Any())
                {
                    var eksikMalzemeAdları = eksikler.Select(em => _context.Malzemeler.Find(em)?.Ad).ToList();
                    uygunTarifler.Add((tarif, eksikMalzemeAdları));
                }
                else
                {

                    uygunTarifler.Add((tarif, null));
                }
            }


            if (!uygunTarifler.Any())
            {
                ViewBag.EksikMalzemeBilgisi = "Seçilen malzemelerle hiçbir tarif bulunamadı.";
            }

            return View("FindRecipes", uygunTarifler);
        }




    }
}