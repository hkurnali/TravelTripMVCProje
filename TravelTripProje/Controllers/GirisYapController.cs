using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Services.Description;
using System.Web.UI.WebControls;
using TravelTripProje.Models.Siniflar;

namespace TravelTripProje.Controllers
{
    public class GirisYapController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin ad)
        {
            var bilgiler = c.Admins.FirstOrDefault(x => x.Kullanıcı == ad.Kullanıcı && x.Sifre == ad.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Kullanıcı, false);
                Session["Kullanıcı"] = bilgiler.Kullanıcı.ToString();
                return RedirectToAction("Index", "Admin");
            }
            else
            {

                return View();
            }

        }

        public ActionResult LogOut()
        {
          FormsAuthentication.SignOut();
            return RedirectToAction("Login", "GirisYap");
        }
    }
}