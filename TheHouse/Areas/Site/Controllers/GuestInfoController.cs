using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;
using TheHouse.Models;
using System;
using System.Linq;
using System.Web;

namespace TheHouse.Areas.Site.Controllers
{
    public class GuestInfoController : Controller
    {
        TheHouseEntities db = new TheHouseEntities();
        // GET: Site/GuestInfo
        public ActionResult Index()
        {
            var RID= Convert.ToInt32( Request.QueryString[0]);
            tbl_RoomsDetails RD = db.tbl_RoomsDetails.Where(r=>r.R_Id==RID).FirstOrDefault();
            Session["RD"] = RD;
            ////TempData["TypeName"] = Request.QueryString[1];
            //ArrayList myarr = new ArrayList();
            //List<string> mylist = new List<string>();
            //mylist.Add(Request.QueryString[0]);
            //mylist.Add(Request.QueryString[1]);
            //Session["RoomInfo"] = mylist;

            
            return View();
        }

        [HttpPost]
        public ActionResult Index(tbl_Guest Guest)
        {
            if (ModelState.IsValid)
            {
                Guest.G_Status = "T";
                Guest.Type = "G";
                db.tbl_Guest.Add(Guest);
                db.SaveChanges();
                ModelState.Clear();
                return RedirectToAction("Create","Booking",new {area="Site" });
                
            }
            else
            {
                return View(Guest);
            }

        }

        public ActionResult Booking()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Booking(tbl_Booking Booking)
        {
            return View(Booking);

        }
    }
}