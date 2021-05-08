using CloudNote.Domain.Entities.Areas;
using CloudNote.Service.NoteApp;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudNote.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private IUserAppService _userAppService;
        public AccountController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public JsonResult LoginSave(UserEntity entity)
        {
            var message = string.Empty;
            try
            {
                _userAppService.InsertOrUpdate(entity);
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return Json(message);
    }

    public IActionResult Logout()
    {
        return View();
    }

    public IActionResult Register()
    {
        return View();
    }

    public IActionResult RegisterSave()
    {
        return View();
    }
}
}
