using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Classes;

namespace TravelTripProje.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog

        Context c = new Context();
        BlogYorum by = new BlogYorum();
        public ActionResult Index()
        {
            by.Deger1 = c.Blogs.ToList();
            by.Deger3= c.Blogs.OrderByDescending(a=>a.ID).Take(3).ToList();
            return View(by);
        }

       
        public ActionResult BlogDetay(int ID)
        {
       

            by.Deger1 = c.Blogs.Where(a => a.ID == ID).ToList();
            by.Deger2=c.Yorumlars.Where(a=>a.Blogid==ID).ToList();
            by.Deger3 = c.Blogs.OrderByDescending(a => a.ID).Take(3).ToList();
            return View(by);
        }

        [HttpGet]
        public PartialViewResult YorumYap(int id)
        {
            ViewBag.ID = id;
            return PartialView();
        }


        [HttpPost]
        public PartialViewResult YorumYap(Yorumlar yorum)
        {
            c.Yorumlars.Add(yorum);
            c.SaveChanges();
            return PartialView();

        }
    }
}