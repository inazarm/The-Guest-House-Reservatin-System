using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheHouse.Models;

namespace TheHouse.Areas.Site.Controllers
{
    public class LoginGuestController : Controller
    {

        TheHouseEntities db;
        // GET: Site/LoginGuest
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(tbl_Guest UserGuest)
        {
            using (db=new TheHouseEntities())
            {
                if (ModelState.IsValid)
                {
                    var Guest = db.tbl_Guest.Where(x => x.G_Email == UserGuest.G_Email && x.G_Pass == UserGuest.G_Pass).FirstOrDefault();
                    if (Guest != null)
                    {
                        return RedirectToAction("Create","Booking");
                    }
                    else
                    {
                        ViewBag.Error = "Invalid User/Password";
                        ModelState.Clear();
                        return View();
                    }
                }
                else
                {
                    ViewBag.Error = "Fields can not be empty!";
                    return View();
                }
             
                
            }
        }
    }
}