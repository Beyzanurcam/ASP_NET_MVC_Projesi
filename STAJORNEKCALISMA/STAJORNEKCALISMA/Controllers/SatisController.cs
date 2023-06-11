using STAJORNEKCALISMA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static STAJORNEKCALISMA.Models.Enumlar;

namespace STAJORNEKCALISMA.Controllers
{
    public class SatisController : Controller
    {
       
        STAJCALISMASIEntities db =new STAJCALISMASIEntities();
        Class1 cs = new Class1();
        // GET: Satis

        [HttpGet]
        public ActionResult HatSatis()
        {
            var hat = db.TBL_HAT.Where(x => x.HAT_DURUM == 2 && x.HATSATIS_DURUM == 1);
            cs.Kisiler = new SelectList(db.TBL_KULLANICI, "ID", "KULLANICI_ADI_SOYADI");
            cs.Hatlar = new SelectList(hat, "ID","HAT_NO");
            return View(cs);
        }

        [HttpPost]
        public ActionResult HatSatis(TBL_HATSATIS model)
        {
            db.sp_hatsatis(model.ID, model.SIFRELIID, model.SATISTARIH, model.HATSATISKULLANICIID, model.HATSATISHATID);
            db.sp_hatsatisdurumdegistir2(model.HATSATISHATID, (int)HatSatisDurum.Satildi);
            return Json(new { sonuc = true });
        }

        [HttpGet]
        public ActionResult HatSatisTanim()
        {
            var hatonay = db.VW_HATSATIS.Where(x => x.HAT_DURUM == 2 && x.HATSATIS_DURUM == 2).ToList();
            return View(hatonay);
        }
        [HttpPost]
        public ActionResult HatSatisTanim(int ID)
        {
            db.sp_hatsatisdurumdegistir(ID, 1);
           // db.sp_hatsatisdurumdegistir(ID,DURUM);
            return Json(new { sonuc = true });
        }
       
    }
}