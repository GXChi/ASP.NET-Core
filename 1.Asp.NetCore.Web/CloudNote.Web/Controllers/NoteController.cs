using CloudNote.Domain.Entities;
using CloudNote.Service.NoteApp;
using CloudNote.Service.NoteApp.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CloudNote.Web.Controllers
{
    public class NoteController : Controller
    {
        private INoteAppService _noteAppService;
        public NoteController(INoteAppService noteAppService)
        {
            _noteAppService = noteAppService;
        }
        // GET: NoteController
        public ActionResult Index()
        {
            ViewData["Name"] = "最新文档";
            var notes = _noteAppService.GetAll();
            return View(notes);
        }

        public JsonResult GetNote(Guid noteID)
        {
            var notes = new NoteDto();
            if (!string.IsNullOrEmpty(noteID.ToString()))
            {
                notes = _noteAppService.Get(noteID);
            }         
            return Json(notes);
        }

        // GET: NoteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NoteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NoteController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(NoteEntity entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (string.IsNullOrWhiteSpace(entity.Id.ToString()))
                    {
                        entity.Id = Guid.NewGuid();
                    }                    
                    _noteAppService.InsertOrUpdate(entity);
                }
                return RedirectToAction(nameof(GetNote),entity.Id);
               
            }
            catch
            {
                return View("Edit");
            }
        }

        // GET: NoteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NoteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NoteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NoteController/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Delete(Guid id)
        {
            try
            {
                _noteAppService.Delete(id);
                return Json("删除成功！");
            }
            catch
            {
                return Json(new Exception().Message);
            }
        }
    }
}
