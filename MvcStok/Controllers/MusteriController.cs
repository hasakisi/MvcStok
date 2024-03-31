using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
namespace MvcStok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MvcDbStokEntities1 db = new MvcDbStokEntities1();

        public ActionResult Index()
        {
            var degerler = db.musteriler.ToList();

            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMusteri(musteriler p1)
        {
            db.musteriler.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult Sil(int id)
        {
            var musteri = db.musteriler.Find(id);
            db.musteriler.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir(int id)
        {
            var mus = db.musteriler.Find(id);
            return View("MusteriGetir", mus);
        }
        public ActionResult Guncelle(musteriler p1)
        {
            var mst = db.musteriler.Find(p1.MUSTERIID);
            mst.MUSTERIAD = p1.MUSTERIAD;
            mst.MUSTERISOYAD = p1.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}