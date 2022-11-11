using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hehimtap.Models;

namespace Hehimtap.Controllers
{
    public class TegController : Controller
    {
        // GET: Teg
        HekimTapEntities db = new HekimTapEntities();
        public ActionResult Index()
        {
            List<Teq> clouds =db.Teqs.Where(x=>x.Status==true).ToList();
            
            return View(clouds);
        }
        public ActionResult CreateTeq(Teq teq)
        {
            teq.Status = true;
            db.Teqs.Add(teq);

           
            db.SaveChanges();

            return RedirectToAction("Index");

            
        }

        public ActionResult Delete(int Id)
        {
            Teq teq = db.Teqs.FirstOrDefault(x => x.Id == Id);
            teq.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult TegCreate(int? newsId,int? tegId)
        {
            CloudDto data = new CloudDto();
            //if (newsId == null)
            //{
            //    data.Clouds = db.Clouds.ToList();
            //}
            //else
            //{
            //    data.Clouds = db.Clouds.Where(w => w.XeberId == newsId).ToList();

            //}

            //if (tegId == null)
            //{
            //    data.Clouds = db.Clouds.ToList();
            //}
            //else
            //{
            //    data.Clouds = db.Clouds.Where(w => w.TeqId == tegId).ToList();

            //}

            //data.News = db.News.ToList();
            //return View(data);

            data.News = db.News.ToList();
            data.Teqs = db.Teqs.Where(x => x.Status == true).ToList();

            return View(data);
        }
        public ActionResult Create(Cloud cl,int Id)
        {
            Cloud cloud = new Cloud();
            cloud.News = db.News.SingleOrDefault(x => x.Id == Id);
            cl.News = db.News.SingleOrDefault(t => t.Id == Id);

            cloud.Teq = db.Teqs.SingleOrDefault(x => x.Id == Id);
            cl.Teq = db.Teqs.SingleOrDefault(t => t.Id == Id);


            db.Clouds.Add(cl);
            db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}