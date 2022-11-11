using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Hehimtap.Models;

namespace Hehimtap.Controllers
{
    public class RegisterDoctorController : Controller
    {
        // GET: RegisterDoctor
        HekimTapEntities db = new HekimTapEntities();

        public ActionResult Index(int? DoctorCategoriesId)
        {
            registerdocDto model = new registerdocDto();
            if (DoctorCategoriesId == null)
            {
                model.Doctors = db.Doctors.Where(w => w.Status == true).ToList();
            }
            else
            {
                model.Doctors = db.Doctors.Where(w => w.Status == true && w.DoctorCategoriesId == DoctorCategoriesId).ToList();

            }


            model.doctorCategories = db.DoctorCategories.Where(w => w.Status == true).ToList();

            return View(model);

           
        }

        public ActionResult DoctorList(Doctor doctor)
        {
            Doctor d = db.Doctors.Where(x=>x.Status==true).FirstOrDefault(x => x.Id == doctor.Id);

            return View(d);
        }

        [AllowAnonymous]
        public ActionResult CreateDoctor()
        {
            List<DoctorCategory> doctorCategories = db.DoctorCategories.Where(x => x.Status == true).ToList();

            return View(doctorCategories);
        }
        [AllowAnonymous]
        public ActionResult Create(Doctor doctor)
        {
            doctor.Status = true;

            db.Doctors.Add(doctor);
            db.SaveChanges();


            return View();
        }

        [HttpGet]
        public ActionResult DoctorProfil()
        {




           

            string Id = Session["Id"].ToString();
            

            var ID = int.Parse(Id);
            var model = db.Doctors.SingleOrDefault
                (x => x.Id == ID);

            //data.doctor = db.Doctors.SingleOrDefault(s => s.Id == Id);
            //data.comments = db.Comments.Where(x => x.DoctorsId == Id).ToList();

            var comment = db.Comments.Where(x => x.DoctorsId == ID).Count().ToString();
            ViewBag.comentsay = comment;


            Beyanat beyanat = db.Beyanats.SingleOrDefault(x => x.DoctorId == ID);      //hekimin seklini getirdik(sekil hekimin beyanat tablesindedir)
            ViewBag.sekil = beyanat.Sekil;
            


           

            return View(model);
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(Doctor d)
        {
            Doctor doctor = db.Doctors.FirstOrDefault(x => x.Mail == d.Mail && x.Sifre == d.Sifre);
            if (doctor != null)
            {
                FormsAuthentication.SetAuthCookie(doctor.Ad, false);
                Session["Id"] = doctor.Id.ToString();



                return RedirectToAction("DoctorProfil", "RegisterDoctor");
            }
            else
            {
                return RedirectToAction("Index", "LoginDoctor");
            }


        }

        //comenteray hissesi

        public PartialViewResult ComentPartial(int Id)
        {
            DocProfileDto model = new DocProfileDto();               //NOT: --Dto ile deyer gonderende Id saxlamaq lazimgelir biz Id view de
                                                                     //  url.actionun icinde, new{Id=Mode.Id} kimisaxladiq (Model evezi x da olabiler)

            
            model.comments = db.Comments.Where(x => x.DoctorsId == Id).ToList();
            return PartialView(model);




        }

        public ActionResult Delete(int Id)
        {
            Comment comment = db.Comments.FirstOrDefault(x => x.Id == Id);
            comment.Status = false;
            db.SaveChanges();
            return RedirectToAction("ComentPartial");
        }



        //Rezerv Ucun

        public ActionResult Rezerv()
        {
            string Id = Session["Id"].ToString();
            var ID = int.Parse(Id);
             
            List<Rezerv> rezervs = db.Rezervs.Where(w=>w.Ziyaret.DoctorsId == ID).ToList();


            return View(rezervs);

        }

        public ActionResult List()
        {
            string Id = Session["Id"].ToString();
            var ID = int.Parse(Id);
            var model = db.Doctors.SingleOrDefault
                (x => x.Id == ID);


            return View(model);
        }

        public ActionResult YenilemeniGetir(int Id)
        {
            Doctor doctor = db.Doctors.FirstOrDefault(x => x.Id == Id);

            return View(doctor);
        }
        public ActionResult Yenile(Doctor doctor)
        {
            Doctor doc= db.Doctors.FirstOrDefault(x => x.Id == doctor.Id);
            doc.Ad = doctor.Ad;
            doc.Soyad = doctor.Soyad;
            doc.Mail = doctor.Mail;
            doc.Unvan = doctor.Unvan;
            doc.Telefon = doctor.Telefon;
            doc.Ixdisas = doctor.Ixdisas;
            doc.Sifre = doctor.Sifre;


            db.SaveChanges();
            

            return RedirectToAction("List");
        }


                                                   //beyanat
        public ActionResult Beyanat()
        {
             
            string Id = Session["Id"].ToString();                                 //Herbir hekin oz beyanatini getirir
                                               
            var id = int.Parse(Id);
            var model = db.Beyanats.SingleOrDefault(x => x.DoctorId == id);




            return View(model);
        }

        public ActionResult BeyanatGetir(int Id)
        {
            //string Id = Session["Id"].ToString();                                

            //var id = int.Parse(Id);
            //var model = db.Beyanats.SingleOrDefault(x => x.DoctorId == id);

            Beyanat beyanat = db.Beyanats.Where(x=>x.Status==true).FirstOrDefault(f => f.Id == Id);


            return View(beyanat);
        }
        public ActionResult BeyanatYenile(Beyanat beyanat, HttpPostedFileBase Sekil)
        {
            Beyanat b = db.Beyanats.FirstOrDefault(f => f.Id == beyanat.Id);
            b.Ixdisas = beyanat.Ixdisas;
            b.Tehsil = beyanat.Tehsil;
         
            db.SaveChanges();
            if (Sekil != null)
            {
                string path = Path.Combine(Server.MapPath("~/Images"), Path.GetFileName(Sekil.FileName));
                Sekil.SaveAs(path);
                b.Sekil = Path.GetFileName(Sekil.FileName);

            }

           
            db.SaveChanges();

            return RedirectToAction("Beyanat");
        }

        public ActionResult CixisEt()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();


            return RedirectToAction("Index", "FindLoginUser"); 
        }

        public ActionResult CixisEtUser()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();


            return RedirectToAction("Index", "FinHomePage");
        }
    }
}