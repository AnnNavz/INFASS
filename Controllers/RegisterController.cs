using Microsoft.AspNetCore.Mvc;
using INFASS.Models;
using INFASS.Services;

namespace INFASS.Controllers
{
	public class RegisterController : Controller
	{
		private readonly IModelOutputLogger _modelOutputLogger;

		public RegisterController(IModelOutputLogger modelOutputLogger)
		{
			_modelOutputLogger = modelOutputLogger;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult SubmitRegistration([FromBody] User userData)
		{
			if (userData == null)
			{
				return BadRequest("No data received.");
			}

			_modelOutputLogger.WriteToOutput(userData, "USER SIGN UP DATA");

			string message = "Successfully received registration for:\n\n" +
				_modelOutputLogger.FormatModel(userData, "Registration Result");

			return Json(message);
		}
	}
}
