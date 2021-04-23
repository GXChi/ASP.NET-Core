﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudNote.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
         
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Logout()
        {
            return View();
        }
    }
}
