using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Classes;

namespace TravelTripProje.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin

        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var degerler=c.Blogs.ToList();
            return View(degerler);
        } 
      
        [HttpGet]
        public ActionResult YeniBlog()
        {
          
            return View();
        }
      
        [HttpPost]
        public ActionResult YeniBlog(Blog blog)
        {
            c.Blogs.Add(blog);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BlogSil(int ID) { 
            var b=c.Blogs.Find(ID);
            c.Blogs.Remove(b);
            c.SaveChanges();
            
            return RedirectToAction("Index");
        }

        public ActionResult BlogGuncelle(int ID)
        {
            var bl = c.Blogs.Find(ID);            
            return View("BlogGuncelle",bl);
        }

        public ActionResult BlogGuncel(Blog blog)
        {
            var blg = c.Blogs.Find(blog.ID);
            blg.Tarih = blog.Tarih;
            blg.BlogImage=blog.BlogImage;
            blg.Aciklama=blog.Aciklama;
            blg.Baslik=blog.Baslik;
            c.SaveChanges();
            return RedirectToAction("Index");          
        }

    }
}