using INFASS.Models;
using INFASS.Services;
using Microsoft.AspNetCore.Mvc;

namespace INFASS.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] Product productData)
        {
            if (productData == null)
            {
                return BadRequest("No product data received.");
            }

            string responseMessage = DynamicModelFormatter.FormatModelData(productData);

            return Json(responseMessage);
        }
    }
}
