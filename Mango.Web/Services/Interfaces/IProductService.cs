using Mango.Web.Model.Dto;
using Mango.Web.Models;

namespace Mango.Web.Services.Interfaces
{
    public interface IProductService
    {
        Task<ResponseDto?> GetProductByName(string name);
        Task<ResponseDto?> GetProductsAsync();
        Task<ResponseDto?> GetProductByIdAsync(int id);
        Task<ResponseDto?> CreateProductAsync(ProductDto couponDto);
        Task<ResponseDto?> UpdateProductAsync(ProductDto couponDto);
        Task<ResponseDto?> DeleteProductAsync(int id);

    }
}
