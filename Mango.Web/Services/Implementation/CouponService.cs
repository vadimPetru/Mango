using Mango.Web.Models;
using Mango.Web.Services.Interfaces;

namespace Mango.Web.Services.Implementation
{
    public class CouponService : ICouponService
    {

        private readonly IBaseService _baseService;

        public CouponService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public Task<ResponseDto?> CreateCouponsAsync(CouponDto couponDto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto?> DeleteCouponsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto?> GetCoupon(string couponCode)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto?> GetCouponByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto?> GetCouponsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto?> UpdateCouponsAsync(CouponDto couponDto)
        {
            throw new NotImplementedException();
        }
    }
}
