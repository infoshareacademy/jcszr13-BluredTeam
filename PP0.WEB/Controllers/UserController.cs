using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PP0.WEB.Interfaces;
using PP0.WEB.Services;
using PP0.WEB.ViewModels;
using PP0.EntityFrameworkCore.Database.Entities;

namespace PP0.WEB.Controllers
{
    public class UserController : Controller
    {
        
        private readonly IUserServiceDb _userServiceDb;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController( IUserServiceDb userServiceDb,
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager
            )
        {
           
            _userServiceDb = userServiceDb;
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        // GET: UserController
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {

            var model = _userServiceDb.GetAllUsers();
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

            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegisterVM model, string? returnUrl = null)
        {

            return View(model);

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
   
                return View();
           
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

                return View();
          
        }


    }
}
