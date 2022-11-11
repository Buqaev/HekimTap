using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Hehimtap.Models;


namespace Hehimtap.Controllers
{
    
    public class FindLoginUserController : Controller
    {
        
        // GET: FindLoginUser
        HekimTapEntities db = new HekimTapEntities();

        [AllowAnonymous]
        public ActionResult Index()
        {
     

            return View();
        }

        
       
        public ActionResult Home(int? DoctorCategoriesId)
        {
            registerdocDto model = new registerdocDto();
            //if (DoctorCategoriesId == null)
            //{
            //    model.Doctors = db.Doctors.Where(w => w.Status == true).ToList();
            //}
            //else
            //{
            //    model.Doctors = db.Doctors.Where(w => w.Status == true && w.DoctorCategoriesId == DoctorCategoriesId).ToList();

            //}
            //model.Doctors = db.Doctors.Where(w => w.DoctorCategoriesId == DoctorCategoriesId).ToList();
            model.Doctors = db.Doctors.Where(w => w.Status == true).ToList();
           
            model.Beyanats = db.Beyanats.Where(x => x.Status == true).ToList();
            model.doctorCategories = db.DoctorCategories.Where(w => w.Status == true).ToList();

            return View(model);
            
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult UserLogin()
        {
         

            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(string Mail , string Sifre)
        {
            User user = db.Users.FirstOrDefault(x => x.Mail == Mail && x.Sifre == Sifre);
            Doctor doctor = db.Doctors.FirstOrDefault(x => x.Mail == Mail && x.Sifre == Sifre);
            Admin admin = db.Admins.FirstOrDefault(x => x.Mail == Mail && x.Sifre == Sifre);
            if (user != null)
            {
                
                FormsAuthentication.SetAuthCookie(user.Ad, false);
                Session["Id"] = user.Id.ToString();
                Session["Ad"] = user.Ad.ToString();
                Session["Soyad"] = user.Soyad.ToString();
                return RedirectToAction("Index", "FinHomePage");
            }
            if (doctor != null)
            {

                FormsAuthentication.SetAuthCookie(doctor.Ad, false);
                Session["Id"] = doctor.Id.ToString();
             
                return RedirectToAction("DoctorProfil", "RegisterDoctor");
            }
            if (admin != null)
            {

                FormsAuthentication.SetAuthCookie(admin.Ad, false);
                Session["Id"] = admin.Id.ToString();

                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return RedirectToAction("Index", "FindLoginUser");
            }


        }


    
        [AllowAnonymous]
        public ActionResult Doctor()
        {
            HekimBeyanatDto data = new HekimBeyanatDto();
            data.Beyanats = db.Beyanats.Where(x => x.Status == true).ToList();
            data.Doctors = db.Doctors.Where(x => x.Status == true).ToList();

            return View(data);
        }

        public ActionResult DoctorCateList(int Id)
        {



            var deyer = db.Beyanats.Where(x => x.Doctor.DoctorCategoriesId == Id).ToList();
          
            return View(deyer);






            
        }
    }
}