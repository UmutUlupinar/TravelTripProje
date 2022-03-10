using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Classes;

namespace TravelTripProje.Controllers
{
    public class AnaSayfaController : Controller
    {
        // GET: AnaSayfa
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler=c.Blogs.Take(3).ToList();
            return View(degerler);
        }

        public PartialViewResult Partial1()
        {
            var degerler= c.Blogs.OrderByDescending(a=>a.ID).Take(2).ToList();

            return PartialView(degerler);   
        }
        public PartialViewResult Partial2()
        {
            var degerler= c.Blogs.Where(a=>a.ID==3).ToList();         
            return PartialView(degerler);   
        }public PartialViewResult Partial3()
        {
            var degerler= c.Blogs.ToList();         
            return PartialView(degerler);   
        }






    }
}