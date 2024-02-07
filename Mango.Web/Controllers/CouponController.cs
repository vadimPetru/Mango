using Mango.Web.Models;
using Mango.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace Mango.Web.Controllers
{
    public class CouponController : Controller
    {
        private readonly ICouponService _couponService;

        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }

        public async Task<IActionResult> Index()
        {
            //Create list Coupons where will be store Coupons of API 
            List<CouponDto?> CoupnsList = new();

            // Get Answer of Api In Json
            var response = await _couponService.GetCouponsAsync();

            // if response good , deserialize json
            if(response != null && response.IsSuccess)
            {
                CoupnsList = JsonConvert.DeserializeObject<List<CouponDto>>(Convert.ToString(response.Result));
            }

            return View(CoupnsList);
        }
        [HttpGet]
        public async Task<IActionResult> CreateCoupon()
        {
            return View();
        }
        [HttpPost]
		public async Task<IActionResult> CreateCoupon(CouponDto model)
		{

            if (ModelState.IsValid)
            {
                ResponseDto? response = await _couponService.CreateCouponsAsync(model);

				if (response != null && response.IsSuccess)
				{
                    return RedirectToAction(nameof(Index));
				}
			}
			return View(model);
		}
	}
}
