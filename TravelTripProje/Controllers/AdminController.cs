using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Siniflar;

namespace TravelTripProje.Controllers
{
    public class AdminController : Controller
    {
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var degerler = c.Blogs.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniBlog(Blog p)
        {
            c.Blogs.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BlogSil(int id)
        {
            var a = c.Blogs.Find(id);
            c.Blogs.Remove(a);
            c.SaveChanges();
            return RedirectToAction("Index");


        }
        public ActionResult BlogGetir(int id)
        {
            var bl = c.Blogs.Find(id);

            return View("BlogGetir", bl);


        }
        public ActionResult BlogGuncelle(Blog b)
        {
            var blg = c.Blogs.Find(b.ID);
            blg.Aciklama = b.Aciklama;
            blg.Baslik=b.Baslik;
            blg.BlogImage = b.BlogImage;
            blg.Tarih=b.Tarih;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult YorumListesi()
        {
            var yorumlar = c.Yorumlars.ToList();
            return View(yorumlar);
        }
        public ActionResult YorumSil(int id)
        {
            var ay = c.Yorumlars.Find(id);
            c.Yorumlars.Remove(ay);
            c.SaveChanges();
            return RedirectToAction("YorumListesi");


        }
        public ActionResult YorumGetir(int id)
        {
            var bl = c.Yorumlars.Find(id);

            return View("YorumGetir", bl);


        }
        public ActionResult YorumGuncelle(Yorumlar b)
        {
            var blg = c.Yorumlars.Find(b.ID);
            blg.KullaniciAdi = b.KullaniciAdi;
            blg.Mail = b.Mail;
            blg.Yorum = b.Yorum;
            blg.Blogid = b.Blogid;
            c.SaveChanges();
            return RedirectToAction("YorumListesi");

        }
    }
}