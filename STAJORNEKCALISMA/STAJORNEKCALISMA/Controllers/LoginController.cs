using STAJORNEKCALISMA.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace STAJORNEKCALISMA.Controllers
{
    public class LoginController : Controller
    {
        STAJCALISMASIEntities db = new STAJCALISMASIEntities ();
        // GET: Login

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Loginn() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Loginn(TBL_KULLANICI p)
        {
            var bilgiler = db.TBL_KULLANICI.FirstOrDefault(x => x.KULLANICI_MAIL == p.KULLANICI_MAIL && x.KULLANICI_SIFRE == p.KULLANICI_SIFRE);
          
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KULLANICI_MAIL, false);
                Session["Mail"]=bilgiler.KULLANICI_MAIL.ToString();
                Session["Adı"] = bilgiler.KULLANICI_ADI.ToString();
                Session["Soyadı"] = bilgiler.KULLANICI_SOYADI.ToString();
                return RedirectToAction("Index", "Anasayfa");
            }
            else
            {
                return View();
            }
            
        }


    }
}