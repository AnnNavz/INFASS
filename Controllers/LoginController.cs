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


            string sqlQuery = DynamicInsert.FormatModelData(loginData);

            return Json(sqlQuery);
        }
    }
}
