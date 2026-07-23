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
        public IActionResult Login([FromBody] LoginLogs loginData)
        {
            if (loginData == null)
            {
                return BadRequest("No login data received.");
            }

            // Generate dynamic INSERT INTO SQL string for LoginLogs
            string sqlQuery = DynamicModelFormatter.FormatModelData(loginData);

            return Json(sqlQuery);
        }
    }
}
