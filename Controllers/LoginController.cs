using Microsoft.AspNetCore.Mvc;

namespace INFASS.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Define your static credentials here
            const string StaticUsername = "admin";
            const string StaticPassword = "password123";

            if (username == StaticUsername && password == StaticPassword)
            {
                // Redirects to the Index action of HomeController
                return RedirectToAction("Index", "Home");
            }

            // If authentication fails, display an error message
            ViewBag.ErrorMessage = "Invalid username or password.";
            return View();
        }
    }
}
