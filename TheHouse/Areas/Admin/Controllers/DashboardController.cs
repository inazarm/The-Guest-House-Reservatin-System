using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheHouse.Models;

namespace TheHouse.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            try
            {
                Response.Cache.SetNoStore();
                if (Session["app"]!=null)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Login", "Login" ,new {area=""});
                }
            }
            catch (Exception)
            {
                
                return RedirectToAction("Login", "Login", new { area = "" });
            }
     
        }
    }
}