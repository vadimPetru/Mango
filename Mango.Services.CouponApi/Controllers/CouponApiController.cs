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
        private readonly ResponseDto _responseDto;


        public CouponApiController(ICouponRepository couponRepository)
        {
            _couponRepository = couponRepository;
            _responseDto = new ResponseDto();
        }

        [HttpGet]
        public async Task<ResponseDto> getAll()
        {
            try
            {
                 _responseDto.Result = await _couponRepository.GetCupons();

            }
            catch(Exception ex)
            {
                _responseDto.Message = ex.Message;
                _responseDto.IsSuccess = false;
            }
            return _responseDto;
        }

        
        [HttpGet("id:int")]
        public async Task<ResponseDto> get(int id)
        {
            try
            {
               _responseDto.Result  = await _couponRepository.GetCouponById(id);
            }
            catch(Exception ex)
            {
                _responseDto.Message = ex.Message;
                _responseDto.IsSuccess = false;
            }
            return _responseDto;
        }
    }
}
