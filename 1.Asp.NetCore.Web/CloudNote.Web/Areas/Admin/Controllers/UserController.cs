using CloudNote.Service.UserApp;
using CloudNote.Service.UserApp.Dtos;
using CloudNote.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Utility.Helper;

namespace CloudNote.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class UserController : BaseController
    {
        private IUserAppService _userAppService;
        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }
        public IActionResult Index()
        {
            ViewData["Name"] = "用户管理";
            var list = _userAppService.GetAllList();
            return View(list); ;
        }

        [HttpPost]
        public JsonResult Index(Guid id)
        {
            ViewData["Name"] = "用户管理";
            string strJson = string.Empty;
            JsonData<UserDto> jsonData = new JsonData<UserDto>();
            if (id == Guid.Empty)
            {
                var data = _userAppService.GetAllList();
                jsonData.Data = data;
                jsonData.Count = data.Count;
            }
            else
            {
                jsonData.Data = new List<UserDto>() { _userAppService.GetUserById(id) };                
            }
            return Json(jsonData); ;
        }

        public IActionResult UserEdit()
        {
            return View();
        }

        public IActionResult UserSave()
        {
            return View();
        }
    }
}
