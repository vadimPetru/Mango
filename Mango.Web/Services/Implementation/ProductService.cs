using Mango.Web.Model.Dto;
using Mango.Web.Models;
using Mango.Web.Services.Interfaces;
using Mango.Web.Utils;
using Microsoft.Extensions.Options;
using Variables;

namespace Mango.Web.Services.Implementation
{
    public class ProductService : IProductService
    {

        private readonly IBaseService _baseService;
        private readonly IOptions<ServiceUrls> _options;
        public ProductService(IBaseService baseService, IOptions<ServiceUrls> options)
        {
            _baseService = baseService;
            _options = options;
        }

        public Task<ResponseDto?> CreateProductAsync(ProductDto productDto)
        {
            return _baseService.SendAsync(new RequestDto()
            {
                ApiTypes = ApiType.POST,
                Data= productDto,
                Url = _options.Value.ProductAPI + "/api/product"
            });
        }

        public Task<ResponseDto?> DeleteProductAsync(int id)
        {
            return _baseService.SendAsync(new RequestDto()
            {
                ApiTypes = ApiType.DELETE,
                Url = _options.Value.ProductAPI + "/api/product/" + id
            });
        }

		public Task<ResponseDto?> GetProductByName(string name)
        {
            return _baseService.SendAsync(new RequestDto()
            {
                ApiTypes = ApiType.GET,
                Url = _options.Value.ProductAPI + "/api/product/GetByName/" + name
            }) ;
        }

        public Task<ResponseDto?> GetProductByIdAsync(int id)
        {
            return _baseService.SendAsync(new RequestDto()
            {
                ApiTypes = ApiType.GET,
                Url = _options.Value.ProductAPI + "/api/product/" + id
            });
        }

        public Task<ResponseDto?> GetProductsAsync()
        {
            return _baseService.SendAsync(new RequestDto() {
                ApiTypes = ApiType.GET,
                Url = _options.Value.ProductAPI + "/api/product"
            });
        }

        public Task<ResponseDto?> UpdateProductAsync(ProductDto productDto)
        {
            return _baseService.SendAsync(new RequestDto()
            {
                ApiTypes = ApiType.PUT,
                Data = productDto,
                Url = _options.Value.ProductAPI + "/api/product"
            });
        }
    }
}
