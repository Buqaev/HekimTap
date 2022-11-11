using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hehimtap.Models;

namespace Hehimtap.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        HekimTapEntities db = new HekimTapEntities();

        [HttpGet]
        public ActionResult Index(int? NewsCategoriesId)
        {

            NewsDto model = new NewsDto();
            if (NewsCategoriesId == null)
            {
                model.News = db.News.ToList();
            }
            else
            {
                model.News = db.News.Where(w => w.NewsCategoriesId == NewsCategoriesId).ToList();

            }


            model.NewsCategories = db.NewsCategories.Where(x=>x.Status==true).ToList();

            return View(model);

         
        }

        public ActionResult NewsCreate()
        {
            List<NewsCategory> newsCategories = db.NewsCategories.Where(x => x.Status == true).ToList();
            ViewBag.Tags = db.Teqs.Where(w => w.Status == true).ToList();
            return View(newsCategories);
        }

        public ActionResult Create(News p, List<int> Tags , HttpPostedFileBase Sekil)
        {
            p.Tarix = DateTime.Now;
            if (Sekil != null)
            {
                string path = Path.Combine(Server.MapPath("~/Images"), Path.GetFileName(Sekil.FileName));
                Sekil.SaveAs(path);
                p.Sekil = Path.GetFileName(Sekil.FileName);

            }
            db.News.Add(p);

            //// Taglari elave edirik!!!!! 
            foreach(int tag in Tags)
            {
                Cloud cloud = new Cloud();
                cloud.XeberId = p.Id;
                cloud.TeqId = tag;
                
                db.Clouds.Add(cloud);
            }


            db.SaveChanges();
            return RedirectToAction("Index");

            
        }

        public ActionResult Remove(int Id)
        {
            News news = db.News.FirstOrDefault(x => x.Id == Id);
            db.News.Remove(news);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult NewsUpdate(int Id)
        {
            News news = db.News.FirstOrDefault(x => x.Id == Id);
            ViewBag.cate = db.NewsCategories.Where(x=>x.Status==true).ToList();

            return View(news);
        }

        public ActionResult Update(News p, HttpPostedFileBase Sekil)
        {
            News news = db.News.FirstOrDefault(x => x.Id == p.Id);
            news.Metn = p.Metn;
            news.Basliq = p.Basliq;
            news.Mezmun = p.Mezmun;
            news.Tarix = DateTime.Now;
            news.NewsCategoriesId = p.NewsCategoriesId;
            if (Sekil != null)
            {
                string path = Path.Combine(Server.MapPath("~/Images"), Path.GetFileName(Sekil.FileName));
                Sekil.SaveAs(path);
                news.Sekil = Path.GetFileName(Sekil.FileName);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}