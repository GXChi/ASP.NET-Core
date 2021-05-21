using CloudNote.Service.RoleApp;
using CloudNote.Service.RoleApp.Dtos;
using CloudNote.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudNote.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : BaseController
    {
        private IRoleAppService _roleAppService;

        public RoleController(IRoleAppService roleAppService)
        {
            _roleAppService = roleAppService;
        }
        public IActionResult Index()
        {
            ViewData["Name"] = "角色管理";
            return View();
        }

        [HttpPost]
        public JsonResult Index(Guid id, int curr = 1, int nums = 20)
        {
            ViewData["Name"] = "角色管理";
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
            return Json(jsonData); ;
        }

        public IActionResult Edit(Guid id)
        {
            var user = _roleAppService.GetById(id);
            if (user == null)
            {
                user = new RoleDto();
            }
            return View(user);
        }

        [HttpPost]
        public JsonResult Save(RoleDto dto)
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
                var isSave = _roleAppService.InsertOrUpdate(dto);
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

        public JsonResult Delete(Guid id)
        {
            var message = string.Empty;
            try
            {
                _roleAppService.Delete(id);
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return Json(message);
        }
    }
}
