using Mango.Services.CouponApi.Models.Dto;

namespace Mango.Services.CouponApi.Repository.Interface
{
    public interface ICouponRepository
    {
        Task AddCoupon(CouponDto coupon);
        Task<CouponDto> GetCouponById(int id);
        Task<IEnumerable<CouponDto>> GetCupons();
    }
}