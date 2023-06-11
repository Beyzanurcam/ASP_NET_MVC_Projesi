using Microsoft.Ajax.Utilities;
using STAJORNEKCALISMA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;

namespace STAJORNEKCALISMA.Controllers
{
    public class KullaniciController : Controller
    {
        STAJCALISMASIEntities db = new STAJCALISMASIEntities();
        // GET: Kullanici
        [Authorize]
        [HttpGet]
        public ActionResult KullaniciTanim()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KullaniciTanim(TBL_KULLANICI model)
        {
          

            model.KULLANICI_ADI_SOYADI = model.KULLANICI_ADI +" "+ model.KULLANICI_SOYADI;
            
            db.sp_kullanici(model.ID, model.SIFRELIID, model.KULLANICI_ADI, model.KULLANICI_SOYADI, model.KULLANICI_MAIL, model.KULLANICI_TEL, model.KULLANICI_SIFRE, model.KAYITTARIHI, model.KULLANICI_ADI_SOYADI, 1);
            return Json(new {sonuc=true});
        }




        // GET: Kullanici
        [Authorize]
        public ActionResult KullaniciListe()
        {
            var kullaniciliste = db.TBL_KULLANICI.ToList();
            return View(kullaniciliste);
        }


        public ActionResult KullaniciSil(int id)
        {
            var kullanicisil = db.TBL_KULLANICI.Find(id);
            db.TBL_KULLANICI.Remove(kullanicisil);
            db.SaveChanges();
            return RedirectToAction("KullaniciListe","Kullanici");
          
        }
        
        public ActionResult KullaniciDetay(int id)
        {
            var kullaniciDetay = db.TBL_KULLANICI.Find(id);
            return View("KullaniciDetay",kullaniciDetay);
        }

        [HttpPost]
        public ActionResult KullaniciGuncelle(TBL_KULLANICI model)
        {
            db.sp_kullanici(model.ID, model.SIFRELIID, model.KULLANICI_ADI, model.KULLANICI_SOYADI, model.KULLANICI_MAIL, model.KULLANICI_TEL, model.KULLANICI_SIFRE, model.KAYITTARIHI, model.KULLANICI_ADI_SOYADI, 2);
            return Json(new { sonuc = true });
        }

        public class DTO_K_KULLANICI
        {
            
            public string KULLANICI_ADI { get; set; }
            public string KULLANICI_SOYADI { get; set; }
            public string KULLANICI_MAIL { get; set; }
            public string KULLANICI_TEL { get; set; }           
            public Nullable<System.DateTime> KAYITTARIHI { get; set; }
        }



    }
}