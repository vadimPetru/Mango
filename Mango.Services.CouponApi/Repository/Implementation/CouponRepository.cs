using AutoMapper;
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
        private readonly IMapper _mapper;

        public CouponRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CouponDto> AddCoupon(CouponDto coupon)
        {
            var couponElement =  _mapper.Map<Coupon>(coupon);
            await _context.Coupons.AddAsync(couponElement);
            await _context.SaveChangesAsync();
            return _mapper.Map<CouponDto>(couponElement);
        }

        public async Task<CouponDto> DeleteCoupon(int id)
        {
            var coupon = await _context.Coupons.FirstAsync(item => item.CouponId == id);
            _context.Coupons.Remove(coupon);
            await _context.SaveChangesAsync();
            return _mapper.Map<CouponDto>(coupon);
        }

        public async Task<CouponDto> GetCouponByCode(string code)
        {
            var couponCode =  await _context.Coupons.FirstAsync(item => item.CouponCode == code);
            return _mapper.Map<CouponDto>(couponCode);
        }

        public async Task<CouponDto> GetCouponById(int id)
        {
            var coupon = await _context.Coupons.SingleOrDefaultAsync(item => item.CouponId == id);
            return  _mapper.Map<CouponDto>(coupon);

        }

        public async Task<IEnumerable<CouponDto>> GetCupons()
        {
            var coupons = await _context.Coupons.ToListAsync();
            return _mapper.Map<IEnumerable<CouponDto>>(coupons);
        }

        public async Task<CouponDto> UpdateCoupon(CouponDto coupon)
        {
            var couponElement = _mapper.Map<Coupon>(coupon);
             _context.Coupons.Update(couponElement);
            await _context.SaveChangesAsync();
            return _mapper.Map<CouponDto>(couponElement);
        }
    }
}
