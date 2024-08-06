using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PP0.WEB.Interfaces;
using PP0.WEB.Models;
using PP0.WEB.Services;
using PP0.WEB.ViewModels;

namespace PP0.WEB.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: UserController
        [Authorize(Roles = "Admin,Doctor")]
        public ActionResult Index()
        {

            var model = _userService.GetAllItems();
            return View(model);
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            var rolesList = new List<SelectListItem>();
            rolesList.Add(new SelectListItem { Text = "Pacjent", Value = "Pacjent" });
            rolesList.Add(new SelectListItem { Text = "Lekarz", Value = "Lekarz" });
            ViewBag.Roles = new SelectList(rolesList, "Value", "Text");
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserViewModel vm)
        {

            try
            {
                User user = new User(vm.Login, vm.Password, new List<Role> { new Role(1, "Pacjent") });
                _userService.Create(user);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
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

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
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
