using Mango.Web.Models;

namespace Mango.Web.Services.Interfaces
{
    public interface ICouponService
    {
        Task<ResponseDto?> GetCouponByCode(string couponCode);
        Task<ResponseDto?> GetCouponsAsync();
        Task<ResponseDto?> GetCouponByIdAsync(int id);
        Task<ResponseDto?> CreateCouponsAsync(CouponDto couponDto);
        Task<ResponseDto?> UpdateCouponsAsync(CouponDto couponDto);
        Task<ResponseDto?> DeleteCouponsAsync(int id);

    }
}
