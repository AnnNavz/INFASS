using Microsoft.AspNetCore.Mvc;
using INFASS.Models;
using INFASS.Services;

namespace INFASS.Controllers
{
	public class RegisterController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

        [HttpPost]
        public IActionResult SubmitRegistration([FromBody] User userData)
        {
            if (userData == null)
            {
                return BadRequest("No user data received.");
            }

            string sqlQuery = DynamicModelFormatter.FormatModelData(userData);

            return Json(sqlQuery);
        }
    }
}
