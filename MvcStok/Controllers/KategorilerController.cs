using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
namespace MvcStok.Controllers
{
    public class KategorilerController : Controller
    {
        // GET: Kategoriler
        MvcDbStokEntities1 db = new MvcDbStokEntities1 ();
        public ActionResult Index()
        {
            var degerler = db.kategoriler.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKategori(kategoriler p1) 
        {  
            db.kategoriler.Add(p1);
            db.SaveChanges();
            return View();
        }
    }
}