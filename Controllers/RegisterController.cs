using Microsoft.AspNetCore.Mvc;
using INFASS.Models;

namespace INFASS.Controllers
{
    public class RegisterController : Controller
    {
        User user = new User();
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

			System.Diagnostics.Debug.WriteLine("================ USER SIGN UP DATA ================");
			System.Diagnostics.Debug.WriteLine($"Fullname:  {userData.FullName}");
			System.Diagnostics.Debug.WriteLine($"Username:  {userData.Username}");
			System.Diagnostics.Debug.WriteLine($"Password:  {userData.Password}");
			System.Diagnostics.Debug.WriteLine("===================================================");

			string message = $"Successfully received registration for: \n" +
				$"\n" +
				$"Fullname: {userData.FullName} \n" +
				$"Username: {userData.Username} \n" +
				$"Password: {userData.Password} \n" +
				$"Confirm Password: {userData.ConfirmPassword}";

			return Json(message);
		}
	}
}
