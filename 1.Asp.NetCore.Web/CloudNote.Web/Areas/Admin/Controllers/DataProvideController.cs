using CloudNote.Service.AuthorityApp.Dtos;
using CloudNote.Service.NoteApp;
using CloudNote.Service.RoleApp;
using CloudNote.Service.RoleApp.Dtos;
using CloudNote.Service.UserApp;
using CloudNote.Service.UserApp.Dtos;
using CloudNote.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudNote.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DataProvideController : BaseController
    {
        private IUserAppService _userAppService;
        private IRoleAppService _roleAppService;
        private IAuthorityAppService _authorityAppService;
        private IUserRoleAppService _userRoleAppService;
        public DataProvideController(IUserAppService userAppService,
            IUserRoleAppService userRoleAppService,
            IRoleAppService roleAppService,
            IAuthorityAppService authorityAppService)
        {
            _userAppService = userAppService;
            _roleAppService = roleAppService;
            _authorityAppService = authorityAppService;
            _userRoleAppService = userRoleAppService;
        }

        [HttpPost]
        public JsonResult GetRoleData(Guid id, int curr = 1, int nums = 20)
        {
            string strJson = string.Empty;
            int count;
            JsonData<RoleDto> jsonData = new JsonData<RoleDto>();
            if (id == Guid.Empty)
            {
                jsonData.Data = _roleAppService.GetPageList(curr, nums, out count, null, x => x.CreateDate);
                jsonData.Count = count;
            }
            else
            {
                var data = _roleAppService.GetPageList(curr, nums, out count, x => x.Id == id, x => x.CreateDate);
                jsonData.Data = data;
                jsonData.Count = count;
            }
            return Json(jsonData); 
        }

        [HttpPost]
        public JsonResult GetUserData(Guid id, int curr = 1, int nums = 20)
        {
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
                var data = _userAppService.GetAllList(curr, nums, out count, x => x.Id == id, x => x.CreateDate);
                jsonData.Data = data;
                jsonData.Count = count;
            }
            return Json(jsonData); ;
        }

        [HttpPost]
        public JsonResult GetAuthorityData(Guid id, int curr = 1, int nums = 20)
        {
            string strJson = string.Empty;
            int count;
            JsonData<AuthorityDto> jsonData = new JsonData<AuthorityDto>();
            if (id == Guid.Empty)
            {
                jsonData.Data = _authorityAppService.GetAllList(curr, nums, out count, null, x => x.CreateDate);
                jsonData.Count = count;
            }
            else
            {
                var data = _authorityAppService.GetAllList(curr, nums, out count, x => x.Id == id, x => x.CreateDate);
                jsonData.Data = data;
                jsonData.Count = count;
            }
            return Json(jsonData); ;
        }


    }
}
