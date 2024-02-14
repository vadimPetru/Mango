using Mango.Web.Model.Dto;
using Mango.Web.Models;
using Mango.Web.Services.Implementation;
using Mango.Web.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Mango.Web.Controllers
{
    public class HomeController(IProductService productService) : Controller
    {

        private readonly IProductService _productService = productService;
        public async Task<IActionResult> Index()
        {
            //Create list Coupons where will be store Product of API 
            List<ProductDto?> ProductList = new();

            // Get Answer of Api In Json
            var response = await _productService.GetProductsAsync();

            // if response good , deserialize json
            if (response != null && response.IsSuccess)
            {
                ProductList = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(ProductList);
        }

        [Authorize]
        public async Task<IActionResult> ProductDetails(int productId)
        {
           
            ProductDto? model = new();

            // Get Answer of Api In Json
            var response = await _productService.GetProductByIdAsync(productId);

            // if response good , deserialize json
            if (response != null && response.IsSuccess)
            {
                model = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
