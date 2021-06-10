using CloudNote.Service.RoleApp;
using CloudNote.Service.RoleApp.Dtos;
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
        private IRoleAppService _roleAppService;
        private IUserRoleAppService _userRoleAppService;
        public UserController(IUserAppService userAppService, IUserRoleAppService userRoleAppService, IRoleAppService roleAppService)
        {
            _userAppService = userAppService;
            _userRoleAppService = userRoleAppService;
            _roleAppService = roleAppService;
        }
        public IActionResult Index()
        {
            ViewData["Name"] = "用户管理";
            return View(); ;
        }

        public IActionResult Edit(Guid id)
        {
            var user = _userAppService.GetUserById(id);
            if (user == null)
            {
                user = new UserDto();
            }
            return View(user);
        }

        [HttpPost]
        public JsonResult Save(UserDto dto)
        {
            var message = string.Empty;
            try
            {
                if (dto.Id == Guid.Empty)
                {
                    dto.CreateDate = DateTime.Now;
                }
                else
                {
                    dto.UpdateDate = DateTime.Now;
                }
                var isSave = _userAppService.InsertOrUpdate(dto);
                if (!isSave)
                {
                    message = "保存失败！";
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return Json(message);
        }

        [HttpPost]
        public JsonResult Delete(Guid id)
        {
            var message = string.Empty;
            try
            {
                _userAppService.Delete(id);
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return Json(message);
        }

        public IActionResult UserAuthorization(Guid id)
        {
            var userData = _userAppService.GetUserById(id);
            ViewBag.RoleData = _roleAppService.GetAllList();
            return View(userData);
        }

        [HttpPost]
        public JsonResult UserRoleSave(string userId, List<UserRoleDto> userRole)
        {
            var message = string.Empty;
            try
            {
                if (!_userRoleAppService.SetRole(userId, userRole))
                {
                    message = "用户分配角色失败！";
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return Json(message);
        }
    }
}
