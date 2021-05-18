using CloudNote.Domain.Entities.Areas;
using CloudNote.Service.UserApp;
using CloudNote.Service.UserApp.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Utility.Helper;

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

        [HttpPost]
        public JsonResult Login(UserEntity entity, string vercode)
        {
            var message = string.Empty;
            if (ModelState.IsValid)
            {
                var user = _userAppService.CheckUser(entity.UserName, entity.PassWord);
                if (user != null)
                {
                    //记录Session
                    HttpContext.Session.SetString("CurrentUserId", user.Id.ToString());
                    HttpContext.Session.Set("CurrentUser", ByteConvertHelper.ObjectToBytes(user));
                }
                else
                {
                    message = "用户名或密码错误。";
                }
            }
            return Json(message);
        }

        public IActionResult RegisterIndex()
        {
            return View();
        }

        [HttpPost]
        public JsonResult RegisterSave(UserDto entity)
        {
            var message = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                    if (!_userAppService.InsertOrUpdate(entity))
                    {
                        message = "注册失败";
                    }
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
            return View("Account/Index");
        }

    }
}
