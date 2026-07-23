using Microsoft.AspNetCore.Mvc;
using INFASS.Models;
using INFASS.Services;

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
		public IActionResult Login(Login loginData)
		{
			const string StaticUsername = "admin";
			const string StaticPassword = "password123";


			if (loginData.Username == StaticUsername && loginData.Password == StaticPassword)
			{
				return RedirectToAction("Index", "Home");
			}

			ViewBag.ErrorMessage = "Invalid username or password.";
			return View();
		}
	}
}
