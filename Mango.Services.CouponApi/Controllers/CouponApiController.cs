using Mango.Services.CouponApi.Models.Dto;
using Mango.Services.CouponApi.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.CouponApi.Controllers
{
    [Route("api/coupon")]
    [ApiController]
    [Authorize]
    public class CouponApiController : ControllerBase
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
            catch (Exception ex)
            {
                _responseDto.Message = ex.Message;
                _responseDto.IsSuccess = false;
            }
            return _responseDto;
        }


        [HttpGet("{id:int}")]
        public async Task<ResponseDto> get(int id)
        {
            try
            {
                _responseDto.Result = await _couponRepository.GetCouponById(id);
            }
            catch (Exception ex)
            {
                _responseDto.Message = ex.Message;
                _responseDto.IsSuccess = false;
            }
            return _responseDto;
        }

        [HttpGet]
        [Route("GetByCode/{code}")]
        public async Task<ResponseDto> get(string code)
        {
            try
            {
                _responseDto.Result = _couponRepository.GetCouponByCode(code);
            }
            catch (Exception ex)
            {
                _responseDto.Message = ex.Message;
                _responseDto.IsSuccess = false;
            }
            return _responseDto;
        }

        [HttpPost]
        public async Task<ResponseDto> Post([FromBody] CouponDto coupon)
        {
            try
            {

                _responseDto.Result = await _couponRepository.AddCoupon(coupon);

            }
            catch (Exception ex)
            {
                _responseDto.Message = ex.Message;
                _responseDto.IsSuccess = false;
            }
            return _responseDto;
        }

        [HttpPut]
        public async Task<ResponseDto> Put([FromBody] CouponDto coupon)
        {
            try
            {

                _responseDto.Result = await _couponRepository.UpdateCoupon(coupon);

            }
            catch (Exception ex)
            {
                _responseDto.Message = ex.Message;
                _responseDto.IsSuccess = false;
            }
            return _responseDto;
        }

        [HttpDelete]
		[Route("{id:int}")]
		public async Task<ResponseDto> Delete(int id)
        {
            try
            {

                _responseDto.Result = await _couponRepository.DeleteCoupon(id);

            }
            catch (Exception ex)
            {
                _responseDto.Message = ex.Message;
                _responseDto.IsSuccess = false;
            }
            return _responseDto;
        }
    }
}
