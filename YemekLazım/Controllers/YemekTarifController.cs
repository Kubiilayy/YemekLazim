using BitirmeProjesiDeneme2.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BitirmeProjesiDeneme2.Controllers
{
    public class YemekTarifController : Controller
    {
        private readonly UygulamaDbContext _context;

        public YemekTarifController(UygulamaDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string search)
        {
            var tarifler = _context.Tarifler.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                tarifler = tarifler.Where(t => t.Ad.Contains(search));
            }

            return View(tarifler.ToList());
        }



        public IActionResult Search(string search)
        {
            var tarifler = _context.Tarifler.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                
                tarifler = tarifler.Where(t => t.Ad.StartsWith(search));
            }

            
            return Json(tarifler.ToList());
        }

        public IActionResult Details(int id)
        {
            var tarif = _context.Tarifler
                .Include(t => t.TarifMalzemeler)
                .ThenInclude(tm => tm.Malzeme)
                .FirstOrDefault(t => t.Id == id);

            if (tarif == null)
            {
                return NotFound();
            }

            return View(tarif);
        }

    }
}