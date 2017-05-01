﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TotalizatorWebApp.Controllers.Admin
{
    public class AdminController : Controller
    {
        public ActionResult GetMatchSchedule()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AdminPage()
        {
            return View();
        }
    }
}