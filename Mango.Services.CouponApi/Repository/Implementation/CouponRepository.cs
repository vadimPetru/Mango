using Mango.Services.CouponApi.Data;
using Mango.Services.CouponApi.Models;
using Mango.Services.CouponApi.Models.Dto;
using Mango.Services.CouponApi.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.CouponApi.Repository.Implementation
{
    public class CouponRepository : ICouponRepository
    {
        private readonly AppDbContext _context;

        public CouponRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddCoupon(CouponDto coupon)
        {
            var couponElement = new Coupon() { CouponId = coupon.CouponId, CouponCode = coupon.CouponCode, DiscountAmount = coupon.DiscountAmount, MinAmount = coupon.MinAmount };
            await _context.Coupons.AddAsync(couponElement);
            await _context.SaveChangesAsync();
        }

       
        public async Task<CouponDto> GetCouponById(int id)
        {
            var coupon = await _context.Coupons.SingleOrDefaultAsync(item => item.CouponId == id);
            return new CouponDto() { CouponId = coupon.CouponId, CouponCode = coupon.CouponCode, DiscountAmount = coupon.DiscountAmount, MinAmount = coupon.MinAmount };

        }

        public async Task<IEnumerable<CouponDto>> GetCupons()
        {
            return await _context.Coupons.Select(item => new CouponDto
            {
                CouponId = item.CouponId,
                CouponCode = item.CouponCode,
                DiscountAmount = item.DiscountAmount,
                MinAmount = item.MinAmount
            }).ToListAsync();
        }

        
    }
}
