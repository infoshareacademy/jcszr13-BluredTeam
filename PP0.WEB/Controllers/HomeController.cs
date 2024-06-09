using Microsoft.AspNetCore.Mvc;
using PP0.WEB.Models;
using PP0.WEB.Services;
using System.Diagnostics;

namespace PP0.WEB.Controllers
{
    public class HomeController : Controller
    {

        ILoginService _loginService;
        public HomeController( ILoginService loginService)
        {
            _loginService = loginService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
