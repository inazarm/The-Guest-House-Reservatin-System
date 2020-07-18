using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheHouse.Models;

namespace TheHouse.Areas.Site.Controllers
{
    public class HomeController : Controller
    {
        TheHouseEntities db = new TheHouseEntities();
        // GET: Site/Home
        public ActionResult Index()
        {
            return View();
         
            
        }
        public PartialViewResult HotelByCity(string q)
        {
            try
            {
                if (q.Length > 0)
                {
                    var HotelList = db.tbl_House.Where(h => h.H_City==q).ToList();
                    return PartialView(HotelList);
                }
                else
                {
                    var HotelList = db.tbl_House.ToList();
                    return PartialView(HotelList);
                }
            }
            catch ( Exception ex)
            {
                var HotelList = db.tbl_House.ToList();
                return PartialView(HotelList);
            }
        }

        public ActionResult RoomDetails()
        {

                int HId =Convert.ToInt32(Request.QueryString[0].ToString());
                var RoomDetail = db.tbl_RoomsDetails.Where(room => room.FK_HouseID == HId).ToList();
            // var HouseName = db.tbl_House.Where(house => house.H_ID == HId).FirstOrDefault();
            //TempData["HouseName"] = Request.QueryString[1].ToString();
                return View(RoomDetail);
            
        }
    }
}