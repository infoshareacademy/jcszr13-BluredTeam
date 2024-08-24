using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PP0.EntityFrameworkCore.Database.Entities;
using PP0.WEB.Interfaces;
using PP0.WEB.Models;
using PP0.WEB.Services;

namespace PP0.WEB.Controllers
{
    public class VisitController : Controller
    {
        private readonly IVisitServiceDb _visitServiceDb;
        private readonly IUserServiceDb _userService;

        public VisitController(IVisitServiceDb visitServiceDb, IUserServiceDb userService)
        {
            _visitServiceDb = visitServiceDb;
            _userService = userService;
        }

        // GET: VisitController
        public ActionResult Index()
        {
            var model = _visitServiceDb.GetAllVisits();
            return View(model);
        }

        // GET: VisitController/Details/5
        public ActionResult Details(int id)
        {
            var model = _visitServiceDb.GetById(id);
            return View(model);
        }

        // GET: VisitController/Create
        [Route("create")]
        public ActionResult Create()
        {
            var users = _userService.GetAllUsers();

            // Jak wykryc ze uzytkownik jest pacjentem????
            var patients = users.Select(x => new SelectListItem(x.Name, x.Id)).ToList();
            // Jak wykryc ze uzytkownik jest lekarzem????
            var doctors = users.Select(x => new SelectListItem(x.Name, x.Id)).ToList();

            var model = new AddVisit()
            {
                Doctors = doctors,
                Patients = patients
            };
            return View(model);
        }

        // POST: VisitController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("create")]
        public ActionResult Create(AddVisit model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var visit = new EntityFrameworkCore.Database.Entities.Visit
                {
                    Date = model.Date,
                    Type = model.Type,
                    Description = model.Description,
                    Prescriptions = model.Prescriptions,
                    Recomendations = model.Recomendations,
                    Referrals = model.Referrals,
                    DoctorId = model.DoctorId,
                    PatientId = model.PatientId
                };

                _visitServiceDb.Create(visit);

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
            var users = _userService.GetAllUsers();
            // Jak wykryc ze uzytkownik jest pacjentem????
            var patients = users.Select(x => new SelectListItem(x.Name, x.Id)).ToList();
            // Jak wykryc ze uzytkownik jest lekarzem????
            var doctors = users.Select(x => new SelectListItem(x.Name, x.Id)).ToList();

            var model = _visitServiceDb.GetById(id);

            var visit = new EditVisit()
            {
                Id = model.Id,
                PatientId = model.PatientId,
                DoctorId = model.DoctorId,
                Date = model.Date,
                Type = model.Type,
                Description = model.Description,
                Prescriptions = model.Prescriptions,
                Recomendations = model.Recomendations,
                Referrals = model.Referrals,
                Doctors = doctors,
                Patients = patients
            };

            return View(visit);
        }

        // POST: VisitController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("edit/{id:int}")]
        public ActionResult Edit(int id, EditVisit model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var visit = new EntityFrameworkCore.Database.Entities.Visit
                {
                    Id = id,
                    Date = model.Date,
                    Type = model.Type,
                    Description = model.Description,
                    Prescriptions = model.Prescriptions,
                    Recomendations = model.Recomendations,
                    Referrals = model.Referrals,
                    DoctorId = model.DoctorId,
                    PatientId = model.PatientId
                };

                _visitServiceDb.Edit(id, visit);

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
            var model = _visitServiceDb.GetById(id);

            return View(model);
        }

        // POST: VisitController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("delete/{id:int}")]
        public ActionResult Delete(int id, EntityFrameworkCore.Database.Entities.Visit model)
        {
            try
            {
                _visitServiceDb.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
