using CloudNote.Service.AuthorityApp.Dtos;
using CloudNote.Service.NoteApp;
using CloudNote.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudNote.Web.Areas.Admin.Controllers
{
    public class AuthorityController : BaseController
    {
        private IAuthorityAppService _authorityAppService;

        public AuthorityController(IAuthorityAppService authorityAppService)
        {
            _authorityAppService = authorityAppService;
        }
        public IActionResult Index()
        {
            ViewData["Name"] = "权限管理";
            return View();
        }

        [HttpPost]
        public JsonResult Index(Guid id, int curr = 1, int nums = 20)
        {
            ViewData["Name"] = "权限管理";
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

        public IActionResult Edit(Guid id)
        {
            var user = _authorityAppService.GetList(id);
            if (user == null)
            {
                user = new AuthorityDto();
            }
            return View(user);
        }

        [HttpPost]
        public JsonResult Save(AuthorityDto dto)
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
                var isSave = _authorityAppService.InsertOrUpdate(dto);
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
                _authorityAppService.Delete(id);
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return Json(message);
        }
    }
}
