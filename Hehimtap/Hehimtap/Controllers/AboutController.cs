using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hehimtap.Models;

namespace Hehimtap.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        HekimTapEntities db = new HekimTapEntities();

        
        public ActionResult Index()
        {
            List<About> abouts = db.Abouts.ToList();

            return View(abouts);
        }

        [HttpGet]
        public ActionResult CreateAbout()
        {
            List<About> abouts = db.Abouts.ToList();

            return View();
        }

        [HttpPost]
        public ActionResult Create(About about, HttpPostedFileBase Sekil)
        {
            

            if (Sekil != null)
            {
                string path = Path.Combine(Server.MapPath("~/Images"), Path.GetFileName(Sekil.FileName));
                Sekil.SaveAs(path);
                about.Sekil = Path.GetFileName(Sekil.FileName);

            }
            db.Abouts.Add(about);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Remove(int Id)
        {
            About about = db.Abouts.FirstOrDefault(x => x.Id == Id);
            db.Abouts.Remove(about);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AboutUpdate(int Id)
        {
            About about = db.Abouts.FirstOrDefault(x => x.Id == Id);

            return View(about);
        }

        public ActionResult Update(About about, HttpPostedFileBase Sekil)
        {
            About a = db.Abouts.FirstOrDefault(x => x.Id == about.Id);
            a.Melumat = about.Melumat;
            if (Sekil != null)
            {
                string path = Path.Combine(Server.MapPath("~/Images"), Path.GetFileName(Sekil.FileName));
                Sekil.SaveAs(path);
                a.Sekil = Path.GetFileName(Sekil.FileName);
            }
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}