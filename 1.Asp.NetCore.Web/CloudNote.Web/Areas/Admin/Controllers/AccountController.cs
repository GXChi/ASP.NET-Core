using CloudNote.Domain.Entities.Areas;
using CloudNote.Service.UserApp;
using CloudNote.Service.UserApp.Dtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Utility.Helper;

namespace CloudNote.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private IUserAppService _userAppService;
        private IUserRoleAppService _userroleAppService;

        public AccountController(IUserAppService userAppService, IUserRoleAppService userRoleAppService)
        {
            _userAppService = userAppService;
            _userroleAppService = userRoleAppService;
        }

        public IActionResult Index()
        {
            var result = _userroleAppService.GetAllList(null);
            var usrerole = _userAppService.GetType();
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
                    List<Claim> Claims = new List<Claim> 
                    {
                        new Claim(ClaimTypes.Name, entity.UserName),
                        new Claim("UserId", entity.Id.ToString()),
                        new Claim(ClaimTypes.NameIdentifier, "UserId")
                    };
                    var identity = new ClaimsIdentity(Claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsPrincipal = new ClaimsPrincipal(identity);
                    HttpContext.User = claimsPrincipal;
                    HttpContext.SignInAsync(claimsPrincipal, new AuthenticationProperties() { IsPersistent = false, }) ;
                    if (identity.AuthenticationType == "Cookies")
                    {
                        //记录Session
                        HttpContext.Session.SetString("CurrentUserId", user.Id.ToString());
                        HttpContext.Session.Set("CurrentUser", ByteConvertHelper.
                              ObjectToBytes(user));
                    }
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
