using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hehimtap.Models;

namespace Hehimtap.Controllers
{

    public class NewsCategoriController : Controller
    {
        // GET: NewsCategori
        HekimTapEntities db = new HekimTapEntities();

        [HttpGet]
        public ActionResult Index()
        {
            List<NewsCategory> newsCategories = db.NewsCategories.Where(x => x.Status == true).ToList();


            return View(newsCategories);
        }

        [HttpPost]
        public ActionResult Create(NewsCategory newsCategory)
        {
            newsCategory.Status = true;
            db.NewsCategories.Add(newsCategory);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Id)
        {
            NewsCategory newsCategory = db.NewsCategories.FirstOrDefault(x => x.Id == Id);
            newsCategory.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UpdateCategori(int Id)
        {
            NewsCategory newsCategory = db.NewsCategories.FirstOrDefault(x => x.Id == Id);

            return View(newsCategory);
        }

        public ActionResult Update(NewsCategory nwc)
        {
            NewsCategory newsCategory = db.NewsCategories.FirstOrDefault(x => x.Id == nwc.Id);
            newsCategory.Ad = nwc.Ad;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}