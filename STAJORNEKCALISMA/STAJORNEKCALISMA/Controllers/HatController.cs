using STAJORNEKCALISMA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static STAJORNEKCALISMA.Models.Enumlar;

namespace STAJORNEKCALISMA.Controllers
{
    public class HatController : Controller
    {
      
        STAJCALISMASIEntities db = new STAJCALISMASIEntities();
        // GET: Hat
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult HatTanim()
        {
            return View();
        }

        [HttpPost]
        public ActionResult HatTanim(TBL_HAT model)
        {
            db.sp_hat(model.ID, model.SIFRELIID, model.HAT_NO, (int)HatDurum.Pasif, model.KAYITTARIH,(int)HatSatisDurum.Satilmadi,1);
            return Json(new { sonuc = true });
           
        }



        [Authorize]
        public ActionResult HatListe()
        {
            var hatliste = db.TBL_HAT.ToList();
            return View(hatliste);
        }

        public ActionResult HatSil(int id)
        {
            var hatsil = db.TBL_HAT.Find(id);
            db.TBL_HAT.Remove(hatsil);
            db.SaveChanges();
            return RedirectToAction("HatListe", "Hat");

        }

        public ActionResult HatDetay(int id)
        {
            var hatDetay = db.TBL_HAT.Find(id);
            return View("HatDetay", hatDetay);
        }


        [HttpPost]
        public ActionResult HatDuzenle(TBL_HAT model)
        {
            db.sp_hat(model.ID, model.SIFRELIID, model.HAT_NO, (int)HatDurum.Pasif, model.KAYITTARIH, (int)HatSatisDurum.Satilmadi, 2);            
            return Json(new { sonuc = true });
        }


    }
}