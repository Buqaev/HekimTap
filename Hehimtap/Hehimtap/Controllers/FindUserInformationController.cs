using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hehimtap.Models;
namespace Hehimtap.Controllers.isdifadeciler
{
    public class FindUserInformationController : Controller
    {
        // GET: FindUserInformation
        HekimTapEntities db = new HekimTapEntities();

        public ActionResult List()
        {
            string Id = Session["Id"].ToString();
            var ID = int.Parse(Id);
            var model = db.Users.SingleOrDefault
                (x => x.Id == ID);


            return View(model);
        }

        public ActionResult UserYenile(int Id)
        {
            User user = db.Users.FirstOrDefault(x => x.Id == Id);

            return View(user);

        }
        public ActionResult Yenile(User user)
        {
            User u = db.Users.FirstOrDefault(x => x.Id == user.Id);
            u.Ad = user.Ad;
            u.Soyad = user.Soyad;
            u.Mail = user.Mail;
            u.TelefonNo = user.TelefonNo;
            //u.BankKartAd = user.BankKartAd;
            //u.BankKartNo = user.BankKartNo;
            //u.KartMuhavizeKod = user.KartMuhavizeKod;
            u.Sifre = user.Sifre;



            db.SaveChanges();


            return RedirectToAction("List");
        }
    }
}