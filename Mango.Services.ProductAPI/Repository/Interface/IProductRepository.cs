

using Mango.Services.ProductAPI.Model.Dto;

namespace Mango.Services.ProductAPI.Repository.Interface
{
    public interface IProductRepository
    {
        Task<ProductDto> AddProduct(ProductDto coupon);
        Task<ProductDto> UpdateProduct(ProductDto coupon);
        Task<ProductDto> DeleteProduct(int id);
        Task<ProductDto> GetProductById(int id);
        Task<ProductDto> GetProductByName(string code);
        Task<IEnumerable<ProductDto>> GetProducts();
    }
}