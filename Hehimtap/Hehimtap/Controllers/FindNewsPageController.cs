using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hehimtap.Models;

namespace Hehimtap.Controllers
{
    
    public class FindNewsPageController : Controller
    {
        // GET: FindNewsPage
        HekimTapEntities db = new HekimTapEntities();
        [AllowAnonymous]
        public ActionResult Index(DoctorCategory doctorCategory, int? CatId, int? TagId,int? page,string p)
        {
            if (page == null)
            {
                page = 1;
            }
            int skip = ((int)page - 1) * 2;

            List<News> data = new List<News>();

            News2Dto model = new News2Dto();
            if(CatId != null )
            {
                data = db.News.Where(w=>w.NewsCategoriesId == CatId).ToList();
                ViewBag.TotalPage = Math.Ceiling(data.Count / 2.00);
                ViewBag.Page = page;
                data = data.Skip(skip).Take(2).ToList();

            }
            else if(TagId != null )
            {

                List<int> nws = db.Clouds.Where(w => w.TeqId == TagId).Select(s=>s.XeberId).ToList();
                data = db.News.Where(w=> nws.Contains(w.Id)).ToList();
                ViewBag.TotalPage = Math.Ceiling(data.Count / 2.00);
                ViewBag.Page = page;
                data = data.Skip(skip).Take(2).ToList();

            }
            else if(p != null && p.Length > 0)
            {
                data = db.News.Where(x=> x.Basliq.Contains(p)).OrderByDescending(o => o.Id).ToList();
                ViewBag.TotalPage = Math.Ceiling(data.Count / 2.00);
                ViewBag.Page = page;
                data = data.Skip(skip).Take(2).ToList();
            }
            else
            {
                data = db.News.OrderByDescending(o => o.Id).ToList();

                ViewBag.TotalPage = Math.Ceiling(data.Count / 2.00);
                ViewBag.Page = page;
                data = data.Skip(skip).Take(2).ToList();

                p = null;
              
            }

            model.news = data;
            model.newsCategories = db.NewsCategories.Where(x => x.Status == true).ToList();
            model.doctorCategories = db.DoctorCategories.Where(x => x.Status == true).ToList();
            model.Teqs = db.Teqs.Where(x => x.Status == true).ToList();
            model.news2 = db.News.OrderByDescending(o => o.Id).ToList();
 
            ViewBag.Axtaris = p;
            ViewBag.CatId = CatId;
            ViewBag.TagId = TagId;


            return View(model);

        }

        //public ActionResult NewsDetay(int Id)
        //{
        //    NewsdetailDto data = new NewsdetailDto();
        //    data.news = db.News.FirstOrDefault(x => x.Id == Id);
        //    data.Reviews = db.Reviews.Where(x => x.XeberId == Id).ToList();

        //        var deyer = db.Reviews.Where(x=>x.XeberId==Id).Count().ToString();
        //        ViewBag.ReviewSay = deyer;



        //    return View(data);
        //}

        [AllowAnonymous]
        [HttpGet]
        public ActionResult NewsDetay(int Id, int? CatId, int? TagId)
        {
           // News2Dto model = new News2Dto();
            NewsdetailDto data = new NewsdetailDto();
            if (CatId != null)
            {
                data.news = db.News.Where(w => w.NewsCategoriesId == CatId).ToList();
            }
            else if (TagId != null)
            {

                List<int> nws = db.Clouds.Where(w => w.TeqId == TagId).Select(s => s.XeberId).ToList();
                data.news = db.News.Where(w => nws.Contains(w.Id)).ToList();

            }
            else
            {
                data.news = db.News.ToList();
            }

            
            data.news2 = db.News.FirstOrDefault(x => x.Id == Id);
            data.Reviews = db.Reviews.Where(x => x.XeberId == Id).ToList();

            var deyer = db.Reviews.Where(x => x.XeberId == Id).Count().ToString();
            ViewBag.ReviewSay = deyer;

            var catesayi = db.Doctors.Where(x => x.DoctorCategoriesId == Id).Count().ToString();
            ViewBag.cs = catesayi;


            data.doctorCategories = db.DoctorCategories.Where(x => x.Status == true).ToList();
            data.newsCategories=db.NewsCategories.Where(x=>x.Status==true).ToList();
            data.Teqs = db.Teqs.Where(x => x.Status == true).ToList();
            DateTime bugun = DateTime.Now;
            data.news3 = db.News.Where(x => x.Tarix == bugun).ToList();
            return View(data);
        }

        [HttpPost]
        public ActionResult NewsDetay(Review r, int id)
        {
            string Id = Session["Id"].ToString();
            var ID = int.Parse(Id);
            r.Tarix = DateTime.Parse(DateTime.Now.ToShortDateString());
            //r.Id = ID;
            NewsdetailDto data = new NewsdetailDto();

            //User user = db.Users.SingleOrDefault(x => x.Id == ID);
            data.User = db.Users.SingleOrDefault(x => x.Id == ID);
            // data.Doctor = db.Doctors.SingleOrDefault(x => x.Id == Id);
            r.Tarix = DateTime.Now;
            r.Status = true;

            r.News = db.News.SingleOrDefault(t => t.Id == id);      //olmasa c date ele

            r.User = db.Users.SingleOrDefault(x => x.Id == ID);


            db.Reviews.Add(r);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
       
    
    }
}