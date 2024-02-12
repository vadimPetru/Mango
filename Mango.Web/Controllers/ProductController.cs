using Mango.Web.Model.Dto;
using Mango.Web.Models;
using Mango.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Mango.Web.Controllers
{
    public class ProductController(IProductService productService) : Controller
    {

        private readonly IProductService _productService = productService;

        public async Task<IActionResult> ProductIndex()
        {
            //Create list Coupons where will be store Coupons of API 
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
        [HttpGet()]
        public async Task<IActionResult> ProductCreate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductDto model)
        {

            if (ModelState.IsValid)
            {
                ResponseDto? response = await _productService.CreateProductAsync(model);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Product Create SuccessFully";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View(model);
        }

        public async Task<IActionResult> ProductDelete(int couponId)
        {
            ResponseDto? response = await _productService.GetProductByIdAsync(couponId);

            if (response != null && response.IsSuccess)
            {
                ProductDto? model = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ProductDelete(CouponDto couponDto)
        {
            ResponseDto? response = await _productService.DeleteProductAsync(couponDto.CouponId);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Product Delete SuccessFully";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(couponDto);
        }
    }
}

