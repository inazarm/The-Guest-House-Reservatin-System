﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheHouse.Models;

namespace TheHouse.Areas.Site.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Site/Payment
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Payment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Payment(tbl_Payment GetPayment)
        {
            return View();
        }
    }
}