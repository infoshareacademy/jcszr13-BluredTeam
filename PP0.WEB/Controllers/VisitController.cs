﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PP0.WEB.Interfaces;
using PP0.WEB.Models;
using PP0.WEB.Services;
using PP0.WEB.ViewModels;

namespace PP0.WEB.Controllers
{
    public class VisitController : Controller
    {
        private IVisitServiceDb _visitServiceDb;
        public VisitController(IVisitServiceDb visitServiceDb)
        {
            _visitServiceDb = visitServiceDb;
            _visitService = new VisitService();
        }

        private readonly VisitService _visitService;

        //public VisitController()
        //{
        //    _visitService = new VisitService();
        //}
           
        // GET: VisitController
        public ActionResult Index()
        {
            var VMmodel = _visitServiceDb.GetAllVisits().Select(x => new VisitVM() 
                { 
                Id = x.Id,
                Date = x.Date,
                Type = x.Type.ToString(),
                DoctorName = x.Doctor?.Name,
                PatientName = x.Patient?.Name
                });
            return View(VMmodel);
        }

        // GET: VisitController/Details/5
        public ActionResult Details(int id)
        {
            var model = _visitService.GetById(id);
            return View(model);
        }

        // GET: VisitController/Create
        [Route ("create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: VisitController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("create")]
        public ActionResult Create(Visit model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                _visitService.Create(model);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VisitController/Edit/5
        [Route("edit/{id:int}")]
        public ActionResult Edit(int id)
        {
            var model = _visitService.GetById(id);

            return View(model);
        }

        // POST: VisitController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("edit/{id:int}")]
        public ActionResult Edit(int id, Visit model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                _visitService.Update(model);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VisitController/Delete/5
        [Route("delete/{id:int}")]
        public ActionResult Delete(int id)
        {
            var model = _visitService.GetById(id);

            return View(model);
        }

        // POST: VisitController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("delete/{id:int}")]
        public ActionResult Delete(int id, Visit model)
        {
            try
            {
                _visitService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
