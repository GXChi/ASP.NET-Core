using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudNote.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult SignIn()
        {
            return View();
        }

        public IActionResult SignOut()
        {
            return View("SignIn");
        }

        public IActionResult Regist()
        {
            return View();
        }

    }
}
