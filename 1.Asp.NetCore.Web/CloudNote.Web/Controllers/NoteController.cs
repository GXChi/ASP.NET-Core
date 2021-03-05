using CloudNote.Domain.Entities;
using CloudNote.Service.NoteApp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            var notes = _noteAppService.GetAll();
            return View(notes);
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
                    entity.Id = Guid.NewGuid();
                    _noteAppService.InsertOrUpdate(entity);
                }
                return RedirectToAction(nameof(Index));
               
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
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
