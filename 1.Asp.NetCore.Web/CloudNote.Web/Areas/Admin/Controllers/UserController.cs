using CloudNote.Service.NoteApp;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudNote.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
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
            var list = _userAppService.GetAll();
            return View(list); ;
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
