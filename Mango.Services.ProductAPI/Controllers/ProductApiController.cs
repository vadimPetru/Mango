using Mango.Services.ProductAPI.Model.Dto;
using Mango.Services.ProductAPI.Models.Dto;
using Mango.Services.ProductAPI.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.CouponApi.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductApiController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ResponseDto _responseDto;


        public ProductApiController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _responseDto = new ResponseDto();
        }

        [HttpGet]
        public async Task<ResponseDto> getAll()
        {
            try
            {
                _responseDto.Result = await _productRepository.GetProducts();

            }
            catch (Exception ex)
            {
                _responseDto.Message = ex.Message;
                _responseDto.IsSuccess = false;
            }
            return _responseDto;
        }


        [HttpGet("{id:int}")]
        public async Task<ResponseDto> get(int id)
        {
            try
            {
                _responseDto.Result = await _productRepository.GetProductById(id);
            }
            catch (Exception ex)
            {
                _responseDto.Message = ex.Message;
                _responseDto.IsSuccess = false;
            }
            return _responseDto;
        }

        [HttpGet]
        [Route("GetByName/{name}")]
        public async Task<ResponseDto> get(string name)
        {
            try
            {
                _responseDto.Result = await _productRepository.GetProductByName(name);
            }
            catch (Exception ex)
            {
                _responseDto.Message = ex.Message;
                _responseDto.IsSuccess = false;
            }
            return _responseDto;
        }

        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<ResponseDto> Post([FromBody] ProductDto product)
        {
            try
            {

                _responseDto.Result = await _productRepository.AddProduct(product);

            }
            catch (Exception ex)
            {
                _responseDto.Message = ex.Message;
                _responseDto.IsSuccess = false;
            }
            return _responseDto;
        }

        [HttpPut]
       [Authorize(Roles = "Admin")]
        public async Task<ResponseDto> Put([FromBody] ProductDto product)
        {
            try
            {

                _responseDto.Result = await _productRepository.UpdateProduct(product);

            }
            catch (Exception ex)
            {
                _responseDto.Message = ex.Message;
                _responseDto.IsSuccess = false;
            }
            return _responseDto;
        }

        [HttpDelete]
		[Route("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<ResponseDto> Delete(int id)
        {
            try
            {

                _responseDto.Result = await _productRepository.DeleteProduct(id);

            }
            catch (Exception ex)
            {
                _responseDto.Message = ex.Message;
                _responseDto.IsSuccess = false;
            }
            return _responseDto;
        }
    }
}
