using STAJORNEKCALISMA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace STAJORNEKCALISMA.Controllers
{
    public class AnasayfaController : Controller
    {
        STAJCALISMASIEntities db = new STAJCALISMASIEntities();
        // GET: Anasayfa
        public ActionResult Index()
        {
            ViewBag.vb_HatSatisOnayBekleyenSayisi = db.VW_HATSATIS.Where(x=> x.HAT_DURUM == 2).Count();
            ViewBag.vb_KullaniciSayisi= db.TBL_KULLANICI.Count();
            
            return View();
        }
    }
}