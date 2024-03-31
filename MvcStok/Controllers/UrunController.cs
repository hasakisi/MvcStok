using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        MvcDbStokEntities1 db = new MvcDbStokEntities1();

        public ActionResult Index()
        {
            var degerler = db.urunler.ToList();

            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> degerler = (from i in db.kategoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString(),
                                             }
                                             ).ToList();  
            ViewBag.dgr = degerler;
            return View();
        }

        [HttpPost]
        public ActionResult YeniUrun(urunler p1)
        {
            var ktg = db.kategoriler.Where(m => m.KATEGORIID == p1.kategoriler.KATEGORIID).FirstOrDefault();
            p1.kategoriler = ktg;
            db.urunler.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}