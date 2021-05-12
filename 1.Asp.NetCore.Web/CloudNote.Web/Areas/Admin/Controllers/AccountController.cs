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
        public JsonResult LoginSave(UserEntity entity, string vercode)
        {
            var message = string.Empty;
            var user = _userAppService.GetAllList(x => x.UserName == entity.UserName);
            if (user == null || user.Count <= 0)
            {
                message = "用户不存在！";
            }
            else if (user[0].PassWord != entity.PassWord)
            {
                message = "密码错误！";
            }
            return Json(message);
        }

        [HttpPost]
        public JsonResult RegisterSave(UserEntity entity)
        {
            var message = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                    if (string.IsNullOrWhiteSpace(entity.Id.ToString()))
                    {
                        entity.Id = Guid.NewGuid();
                    }
                    _userAppService.InsertOrUpdate(entity);
                }

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
