using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Hehimtap.Models;

namespace Hehimtap.Controllers
{
    [AllowAnonymous]
    public class LoginDoctorController : Controller
    {
        // GET: LoginDoctor
        HekimTapEntities db = new HekimTapEntities();

        
        //public ActionResult Index()
        //{
        //    return View();
        //}


        //[HttpGet]
        //public ActionResult DoctorProfil()
        //{
        //    List<Doctor> doctors = db.Doctors.Where(x=>x.Status==true).ToList();

        //    return View(doctors);
        //}
        //[HttpPost]
        //public ActionResult Login(Doctor d)
        //{
        //    Doctor doctor = db.Doctors.FirstOrDefault(x => x.Mail == d.Mail && x.Sifre == d.Sifre);
        //    if (doctor != null)
        //    {
        //        FormsAuthentication.SetAuthCookie(doctor.Ad, false);
        //        Session["Ad"] = doctor.Ad.ToString();
        //        return RedirectToAction("DoctorProfil", "LoginDoctor");
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index");
        //    }


        //}


    }
}