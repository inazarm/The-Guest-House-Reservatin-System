using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheHouse.Models;

namespace TheHouse.Areas.Site.Controllers
{
    public class HouseDetailsController : Controller
    {
        TheHouseEntities db = new TheHouseEntities();
        // GET: Site/HouseDetails
        public ActionResult Index()
        {
            return View(db.tbl_House.ToList());
        }
    }
}