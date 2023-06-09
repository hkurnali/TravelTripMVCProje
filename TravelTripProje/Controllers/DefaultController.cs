﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Siniflar;

namespace TravelTripProje.Controllers
{
    public class DefaultController : Controller
    {
        Context b = new Context();
        // GET: Default
        public ActionResult Index()
        {

            var degerler = b.Blogs.Take(10).ToList();

            return View(degerler);
        }
        public PartialViewResult Partial1()

        {

            var degerler = b.Blogs.OrderByDescending(x => x.ID).Take(2).ToList();
            return PartialView(degerler);
        }

        public PartialViewResult Partial2()
        {
            var deger = b.Blogs.Where(x => x.ID == 1).ToList();
            return PartialView(deger);
        }
        public PartialViewResult Partial3()
        {
            var degerler = b.Blogs.Take(10).ToList();
            return PartialView(degerler);
        }


        public PartialViewResult Partial4()

        {

            var degerler = b.Blogs.Take(3).ToList();
            return PartialView(degerler);
        }
        public PartialViewResult Partial5()

        {

            var degerler = b.Blogs.OrderByDescending(x => x.ID > 5).Take(3).ToList();
            return PartialView(degerler);
        }
       

    }
}