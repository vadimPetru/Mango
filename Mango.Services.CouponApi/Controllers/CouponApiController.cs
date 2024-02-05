using Mango.Services.CouponApi.Models.Dto;
using Mango.Services.CouponApi.Repository.Interface;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Mango.Services.CouponApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponApiController: ControllerBase
    {
        private readonly ICouponRepository _couponRepository;

        public CouponApiController(ICouponRepository couponRepository)
        {
            _couponRepository = couponRepository;
        }

        [HttpGet]
        public Task<IEnumerable<CouponDto>> getAll()
        {
            try
            {
                 return _couponRepository.GetCupons();

            }
            catch(Exception ex)
            {

            }
            return null;
        }

        
        [HttpGet("id:int")]
        public Task<CouponDto> get(int id)
        {
            try
            {
               return  _couponRepository.GetCouponById(id);
            }
            catch(Exception ex)
            {

            }
            return null;
        }
    }
}
