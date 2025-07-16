using BitirmeProjesiDeneme2.Models;
using BitirmeProjesiDeneme2.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BitirmeProjesiDeneme2.Controllers
{
    public class AdminMalzemeController : Controller
    {
        private readonly UygulamaDbContext _context;

        public AdminMalzemeController(UygulamaDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var malzemeler = _context.Malzemeler.ToList();
            return View(malzemeler);
        }

        [HttpGet]
        public ActionResult MalzemeEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MalzemeEkle(Malzeme m)
        {
            _context.Malzemeler.Add(m);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MalzemeSil(int id)
        {
            var malzeme = _context.Malzemeler.Find(id);
            _context.Malzemeler.Remove(malzeme);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult MalzemeGuncelle(int id)
        {
            var malzeme = _context.Malzemeler.Find(id);
            return View(malzeme);
        }

        [HttpPost]
        public ActionResult MalzemeGuncelle(Malzeme m)
        {
            var malzeme = _context.Malzemeler.Find(m.Id);
            malzeme.Ad = m.Ad;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
