using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hehimtap.Models;
namespace Hehimtap.Controllers.isdifadeciler
{
    //[Authorize]
    //public class FindHekimController : Controller
    //{
        
    //    // GET: FindHekim
    //    HekimTapEntities db = new HekimTapEntities();
       
    //    public ActionResult Index()
    //    {

    //        List<Beyanat> data = db.Beyanats.Where(x => x.Status == true).ToList();

            


    //        return View(data);
    //    }

    //    public ActionResult MelumatGetr(int Id)
    //    {


    //        //string Id = Session["Id"].ToString();



    //        //var mesaj = db.Doctors.OrderByDescending(x => x.Id).ToList();


    //        //var ID = int.Parse(Id);
    //        //var model = db.Doctors.SingleOrDefault
    //        //    (x => x.Id == ID);


    //        DoctorDto data = new DoctorDto();

    //        Beyanat beyanat = db.Beyanats.SingleOrDefault(x => x.DoctorId == Id);      //hekimin seklini getirdik(sekil hekimin beyanat tablesindedir)
    //        ViewBag.sekil = beyanat.Sekil;


    //        data.doctor = db.Doctors.FirstOrDefault(x => x.Id == Id);
    //        data.comments = db.Comments.Where(w => w.DoctorsId == Id).ToList();
    //        data.Beyanats = db.Beyanats.Where(w => w.DoctorId == Id).ToList();
    //        data.Ziyarets = db.Ziyarets.Where(w => w.DoctorsId == Id).ToList();
    //        data.user = db.Users.FirstOrDefault(x => x.Id == Id);
    //        return View(data);
    //    }


    //    [HttpGet]
    //    public ActionResult YeniComment(int Id)
    //    {
    //        CommentDto data = new CommentDto();
    //        //String Id = Session["Id"].ToString();  //olmasa burani userId ver
    //        //var ID = int.Parse(Id);
    //        data.Doctor = db.Doctors.SingleOrDefault(x => x.Id == Id);
    //        //data.User = db.Users.FirstOrDefault(x => x.Id == ID);

        
    //        return View(data);
    //    }

    //    //[HttpPost]
    //    //public ActionResult YeniComment(Comment c,int Id)   //saba prtojenin vidyosuna bax
    //    //{
    //    //    CommentDto data=new CommentDto();
    //    //    String id = Session["Id"].ToString();  //olmasa burani userId ver
    //    //    var ID = int.Parse(id);
    //    //    //User user = db.Users.SingleOrDefault(x => x.Id == ID);
    //    //    data.User = db.Users.SingleOrDefault(x => x.Id == ID);
    //    //   // data.Doctor = db.Doctors.SingleOrDefault(x => x.Id == Id);
    //    //    c.Tarix = DateTime.Now;
    //    //    c.Status = true;
    //    //    c.Ulduzsayi = 1;
    //    //     c.Doctor = db.Doctors.SingleOrDefault(t => t.Id == Id);      //olmasa c date ele
           
    //    //    c.User = db.Users.SingleOrDefault(x => x.Id == ID);
            
    //    //    db.Comments.Add(c);
    //    //    db.SaveChanges();

    //    //    return RedirectToAction("Index");
    //    //}

    //    [HttpGet]
    //    public PartialViewResult BTNpartial(int Id)
    //    {
    //        User user = db.Users.SingleOrDefault(x => x.Id == Id);

           
    //        return PartialView(user);
    //    }

    //    [HttpPost]
    //    public PartialViewResult BTNpartial(Comment c)
    //    {

    //        return PartialView();
    //    }
    //}
}
    
