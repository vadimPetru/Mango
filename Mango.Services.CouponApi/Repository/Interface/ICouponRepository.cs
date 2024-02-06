using Mango.Services.CouponApi.Models.Dto;

namespace Mango.Services.CouponApi.Repository.Interface
{
    public interface ICouponRepository
    {
        Task<CouponDto> AddCoupon(CouponDto coupon);
        Task<CouponDto> UpdateCoupon(CouponDto coupon);
        Task<CouponDto> DeleteCoupon(int id);
        Task<CouponDto> GetCouponById(int id);
        Task<CouponDto> GetCouponByCode(string code);
        Task<IEnumerable<CouponDto>> GetCupons();
    }
}