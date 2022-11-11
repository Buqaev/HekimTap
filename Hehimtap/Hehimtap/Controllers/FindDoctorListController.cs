using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hehimtap.Models;
using PagedList;
using PagedList.Mvc;


namespace Hehimtap.Controllers
{
    
    public class FindDoctorListController : Controller
    {
        // GET: FindDoctorList
        HekimTapEntities db = new HekimTapEntities();
        [AllowAnonymous]
        public ActionResult Index(string p , int? page)
        {
            if (page == null)
            {
                page = 1;
            }
            int skip = ((int)page - 1) * 2;

            List<Beyanat> data = new List<Beyanat>();
            //Axtaris var
            if(p != null && p.Length > 0)
            {
                data = db.Beyanats.Where(x => x.Status == true && x.Doctor.Ad.Contains(p)).OrderByDescending(o => o.Id).ToList();

                ViewBag.TotalPage = Math.Ceiling(data.Count / 2.00);
                ViewBag.Page = page;
                data = data.Skip(skip).Take(2).ToList();
            }

            //Axtaris yoxdur
            else
            {
                data = db.Beyanats.Where(x => x.Status == true).OrderByDescending(o=>o.Id).ToList();

                ViewBag.TotalPage = Math.Ceiling(data.Count / 2.00);
                ViewBag.Page = page;
                data = data.Skip(skip).Take(2).ToList();
                
                p = null;
            }

            ViewBag.Axtaris = p;

            


           




            return View(data);

           



        }
        [AllowAnonymous]
        public ActionResult MelumatGetr(int Id/*, int ComSay, int UlduzSay*/)
        {


            //string Id = Session["Id"].ToString();

            

            //var mesaj = db.Doctors.OrderByDescending(x => x.Id).ToList();


            ////var ID = int.Parse(Id);
            ////    var model = db.Doctors.SingleOrDefault
            ////        (x => x.Id == ID);


            DoctorDto data = new DoctorDto();

            Beyanat beyanat = db.Beyanats.SingleOrDefault(x => x.DoctorId == Id);      //hekimin seklini getirdik(sekil hekimin beyanat tablesindedir)


           
            Doctor doctor = db.Doctors.FirstOrDefault(x => x.Id == Id);
            // Baxis sayi deyis
            doctor.Baxissayi = (doctor.Baxissayi + 1);

            data.doctor = doctor;
            db.SaveChanges();

            

            data.comments = db.Comments.Where(w => w.DoctorsId == Id).ToList();
            data.Beyanats = db.Beyanats.Where(w => w.DoctorId == Id).ToList();
            data.Ziyarets = db.Ziyarets.Where(w => w.DoctorsId == Id).ToList();
            data.user = db.Users.FirstOrDefault(x => x.Id == Id);

            //ulduzlarin ortalamasi
           int ComSay = db.Comments.Where(x=>x.DoctorsId==Id).Count();
           int deyer = (from x in db.Comments.Where(w=>w.DoctorsId==Id) select  x.Ulduzsayi).Sum();
          
           double orta = deyer / ComSay;

            ViewBag.orta = orta;

            // ulduzlarin sayi
            var say = (from x in db.Comments.Where(w => w.DoctorsId == Id) select x.Ulduzsayi).Sum().ToString();

            ViewBag.say = say;



            return View(data);
        }






        [HttpGet]
        [AllowAnonymous]
        public ActionResult YeniComment(int Id)
        {
            CommentDto data = new CommentDto();
            //String Id = Session["Id"].ToString();  //olmasa burani userId ver
            //var ID = int.Parse(Id);
            data.Doctor = db.Doctors.SingleOrDefault(x => x.Id == Id);
            //data.User = db.Users.FirstOrDefault(x => x.Id == ID);


            return View(data);
        }

        [HttpPost]
        public ActionResult YeniComment(Comment c, int Id , int rating)   //saba prtojenin vidyosuna bax
        {
            CommentDto data = new CommentDto();
            String id = Session["Id"].ToString();  //olmasa burani userId ver
            var ID = int.Parse(id);
            //User user = db.Users.SingleOrDefault(x => x.Id == ID);
            data.User = db.Users.SingleOrDefault(x => x.Id == ID);
            // data.Doctor = db.Doctors.SingleOrDefault(x => x.Id == Id);
            c.Tarix = DateTime.Now;
            c.Status = true;
            c.Ulduzsayi = rating;
            c.Doctor = db.Doctors.SingleOrDefault(t => t.Id == Id);      //olmasa c date ele

            c.User = db.Users.SingleOrDefault(x => x.Id == ID);

            db.Comments.Add(c);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public ActionResult Axdar(string p)
        {
            //var deyer = c.KargoDetays.ToList();
            //var k = from x in db.Doctors select x;
            if (!string.IsNullOrEmpty(p))
            {
               List<Doctor> doc = db.Doctors.Where(y => y.Ad.Contains(p)).ToList();
                return View(doc);
            }
            return View();


        }

        public ActionResult HekimIzleme(string id)
        {

            var deyer = db.Beyanats.Where(x => x.Doctor.Ad == id).ToList();
            
            return View(deyer);
        }

        public ActionResult GetEvents()
        {

            var events = db.Rezervs.ToList();



            return new JsonResult {Data =events,JsonRequestBehavior=JsonRequestBehavior.AllowGet };
        }

    }
}