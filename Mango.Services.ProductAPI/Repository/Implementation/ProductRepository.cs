using AutoMapper;
using Mango.Services.ProductAPI.Data;
using Mango.Services.ProductAPI.Model;
using Mango.Services.ProductAPI.Model.Dto;
using Mango.Services.ProductAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.ProductAPI.Repository.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductDto> AddProduct(ProductDto coupon)
        {
            var couponElement =  _mapper.Map<Product>(coupon);
            await _context.Products.AddAsync(couponElement);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductDto>(couponElement);
        }

        public async Task<ProductDto> DeleteProduct(int id)
        {
            var coupon = await _context.Products.FirstAsync(item => item.ProductId == id);
            _context.Products.Remove(coupon);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductDto>(coupon);
        }

        public async Task<ProductDto> GetProductByName(string name)
        {
            var couponCode =  await _context.Products.FirstAsync(item => item.Name == name);
            return _mapper.Map<ProductDto>(couponCode);
        }

        public async Task<ProductDto> GetProductById(int id)
        {
            var coupon = await _context.Products.SingleOrDefaultAsync(item => item.ProductId == id);
            return  _mapper.Map<ProductDto>(coupon);

        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var coupons = await _context.Products.ToListAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(coupons);
        }

        public async Task<ProductDto> UpdateProduct(ProductDto coupon)
        {
            var couponElement = _mapper.Map<Product>(coupon);
             _context.Products.Update(couponElement);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductDto>(couponElement);
        }
    }
}
