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
            //var list = _userAppService.GetAllList();
            return View(); ;
        }

        //[HttpPost]
        //public JsonResult Index(Guid id)
        //{
        //    ViewData["Name"] = "用户管理";
        //    string strJson = string.Empty;
        //    JsonData<UserDto> jsonData = new JsonData<UserDto>();
        //    if (id == Guid.Empty)
        //    {
        //        var data = _userAppService.GetAllList();
        //        jsonData.Data = data;
        //        jsonData.Count = data.Count;
        //    }
        //    else
        //    {
        //        jsonData.Data = new List<UserDto>() { _userAppService.GetUserById(id) };
        //    }
        //    return Json(jsonData); ;
        //}

        [HttpPost]
        public JsonResult Index(Guid id, int curr = 1, int nums = 20)
        {
            ViewData["Name"] = "用户管理";
            string strJson = string.Empty;
            int count;
            JsonData<UserDto> jsonData = new JsonData<UserDto>();
            if (id == Guid.Empty)
            {
                jsonData.Data = _userAppService.GetAllList(curr, nums, out count, null, x => x.CreateDate);                
                jsonData.Count = count;
            }
            else
            {
                var data = _userAppService.GetAllList(curr, nums, out count, x=>x.Id == id, x => x.CreateDate);
                jsonData.Data = data;
                jsonData.Count = count;
            }
            return Json(jsonData); ;
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
            JsonData<UserDto> userData = new JsonData<UserDto>();
            userData.Data = new List<UserDto>();
            userData.Data.Add(_userAppService.GetUserById(id));

            if (userData.Data != null && userData.Data.Count > 0)
            {
                ViewBag.UserRole = userData;
            }

            JsonData<RoleDto> roleData = new JsonData<RoleDto>();
            roleData.Data = _roleAppService.GetAllList();
            ViewBag.RoleData = roleData;

            JsonData<UserRoleDto> userRoleData = new JsonData<UserRoleDto>();
            userRoleData.Data = _userRoleAppService.GetAllList(null);
            return View(userRoleData); 
        }

        public JsonResult UserAuthorizationSave(UserRoleDto dto)
        {
            var message = string.Empty;
            try
            {
                if (!_userRoleAppService.InsertOrUpdate(dto))
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
