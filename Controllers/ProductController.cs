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

            string sqlQuery = DynamicInsert.FormatModelData(productData);

            return Json(sqlQuery);
        }

        [HttpPost]
        public IActionResult UpdateProduct([FromBody] Product productData)
        {
            if (productData == null)
            {
                return BadRequest("No product data received.");
            }

            string sqlQuery = DynamicUpdate.FormatUpdateData(productData);

            return Json(sqlQuery);
        }

        [HttpPost]
        public IActionResult DeleteProduct([FromBody] Product productData)
        {
            if (productData == null)
            {
                return BadRequest("No product data received.");
            }

            // Generates DELETE FROM Product WHERE Id = [id];
            string sqlQuery = DynamicDelete.FormatDeleteData(productData);

            return Json(sqlQuery);
        }

        [HttpPost]
        public IActionResult ViewProducts([FromBody] Product productData)
        {
            if (productData == null)
            {
                productData = new Product();
            }

            // Generates SELECT * FROM Product;
            string sqlQuery = DynamicView.FormatViewData(productData);

            return Json(sqlQuery);
        }

    }
}
