using Microsoft.AspNetCore.Mvc;
using INFASS.Models;
using INFASS.Services;

namespace INFASS.Controllers
{
	public class LoginController : Controller
	{
		private readonly IModelOutputLogger _modelOutputLogger;

		public LoginController(IModelOutputLogger modelOutputLogger)
		{
			_modelOutputLogger = modelOutputLogger;
		}

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

			_modelOutputLogger.WriteToOutput(loginData, "LOGIN ATTEMPT DATA");

			if (loginData.Username == StaticUsername && loginData.Password == StaticPassword)
			{
				return RedirectToAction("Index", "Home");
			}

			ViewBag.ErrorMessage = "Invalid username or password.";
			return View();
		}
	}
}
