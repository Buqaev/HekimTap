using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hehimtap.Models;
namespace Hehimtap.Controllers.isdifadeciler
{
 
    //[Authorize]
    //public class FindXeberlerController : Controller
    //{
    //    // GET: FindXeberler
    //    HekimTapEntities db = new HekimTapEntities();
        
    //    public ActionResult Index(DoctorCategory doctorCategory)
    //    {
    //        News2Dto model = new News2Dto();
    //        model.news = db.News.ToList();
    //        model.newsCategories = db.NewsCategories.Where(x => x.Status == true).ToList();
    //        model.doctorCategories = db.DoctorCategories.Where(x => x.Status == true).ToList();
    //        model.Teqs = db.Teqs.Where(x => x.Status == true).ToList();
    //        model.Clouds = db.Clouds.ToList();


    //        return View(model);
    //    }

    //    [HttpGet]
    //    public ActionResult NewsDetay(int Id)
    //    {

    //        NewsdetailDto data = new NewsdetailDto();
    //        data.news = db.News.FirstOrDefault(x => x.Id == Id);
    //        data.Reviews = db.Reviews.Where(x => x.XeberId == Id).ToList();
            
    //        var deyer = db.Reviews.Where(x => x.XeberId == Id).Count().ToString();
    //        ViewBag.ReviewSay = deyer;

    //        var catesayi = db.Doctors.Where(x => x.DoctorCategoriesId == Id).Count().ToString();
    //        ViewBag.cs = catesayi;

    //        return View(data);
    //    }

    //    [HttpPost]
    //    public ActionResult NewsDetay(Review r,int id)
    //    {
    //        string Id =Session["Id"].ToString();
    //        var ID = int.Parse(Id);
    //        r.Tarix = DateTime.Parse(DateTime.Now.ToShortDateString());
    //        //r.Id = ID;
    //        NewsdetailDto data = new NewsdetailDto();
            
    //        //User user = db.Users.SingleOrDefault(x => x.Id == ID);
    //        data.User = db.Users.SingleOrDefault(x => x.Id == ID);
    //        // data.Doctor = db.Doctors.SingleOrDefault(x => x.Id == Id);
    //        r.Tarix = DateTime.Now;
    //        r.Status = true;

    //        r.News = db.News.SingleOrDefault(t => t.Id == id);      //olmasa c date ele

    //        r.User = db.Users.SingleOrDefault(x => x.Id == ID);


    //        db.Reviews.Add(r);
    //        db.SaveChanges();
    //        return RedirectToAction("Index");
    //    }


    //}
}