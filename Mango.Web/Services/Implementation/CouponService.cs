using Mango.Web.Models;
using Mango.Web.Services.Interfaces;
using Mango.Web.Utils;
using Microsoft.Extensions.Options;
using Variables;

namespace Mango.Web.Services.Implementation
{
    public class CouponService : ICouponService
    {

        private readonly IBaseService _baseService;
        private readonly IOptions<ServiceUrls> _options;
        public CouponService(IBaseService baseService, IOptions<ServiceUrls> options)
        {
            _baseService = baseService;
            _options = options;
        }

        public Task<ResponseDto?> CreateCouponsAsync(CouponDto couponDto)
        {
            return _baseService.SendAsync(new RequestDto()
            {
                ApiTypes = ApiType.POST,
                Data=couponDto,
                Url = _options.Value.CouponAPI + "api/coupon"
            });
        }

        public Task<ResponseDto?> DeleteCouponsAsync(int id)
        {
            return _baseService.SendAsync(new RequestDto()
            {
                ApiTypes = ApiType.DELETE,
                Url = _options.Value.CouponAPI + "api/coupon/" + id
            });
        }

        public Task<ResponseDto?> GetCouponByCode(string couponCode)
        {
            return _baseService.SendAsync(new RequestDto()
            {
                ApiTypes = ApiType.GET,
                Url = _options.Value.CouponAPI + "api/coupon/GetByCode/" + couponCode
            }) ;
        }

        public Task<ResponseDto?> GetCouponByIdAsync(int id)
        {
            return _baseService.SendAsync(new RequestDto()
            {
                ApiTypes = ApiType.GET,
                Url = _options.Value.CouponAPI + "api/coupon/" + id
            });
        }

        public Task<ResponseDto?> GetCouponsAsync()
        {
            return _baseService.SendAsync(new RequestDto() {
                ApiTypes = ApiType.GET,
                Url = _options.Value.CouponAPI +"/api/coupon"
            });
        }

        public Task<ResponseDto?> UpdateCouponsAsync(CouponDto couponDto)
        {
            return _baseService.SendAsync(new RequestDto()
            {
                ApiTypes = ApiType.PUT,
                Data = couponDto,
                Url = _options.Value.CouponAPI + "api/coupon"
            });
        }
    }
}
