using Mango.Web.Models;
using Mango.Web.Services.Interfaces;
using Mango.Web.Utils;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using Variables;

namespace Mango.Web.Services.Implementation
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ITokenProvider _tokenProvider;

        public BaseService(IHttpClientFactory httpClientFactory, ITokenProvider tokenProvider)
        {
            _httpClientFactory = httpClientFactory;
            _tokenProvider = tokenProvider;
        }

        public async Task<ResponseDto?> SendAsync(RequestDto requestDto, bool withBearer = true)
        {
            try
            {

            
            HttpClient client = _httpClientFactory.CreateClient("MangoAPI");
            HttpRequestMessage message = new();
            message.Headers.Add("Accept", "application/json");
                //token 
                if (withBearer)
                {
                    message.Headers.Add("Authorization", $"Bearer {_tokenProvider.GetToken()}");
                }
            message.RequestUri = new Uri(requestDto.Url);
            if(requestDto is not null)
            {
                message.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8 , "application/json");
            }

            HttpResponseMessage response = null;

                message.Method = requestDto.ApiTypes switch
                {
                    ApiType.POST => HttpMethod.Post,
                    ApiType.DELETE => HttpMethod.Delete,
                    ApiType.PUT => HttpMethod.Put,
                    _ => HttpMethod.Get,
                };
                response = await client.SendAsync(message);


                return response.StatusCode switch
                {
                    HttpStatusCode.NotFound => new() { IsSuccess = false, Message = "Not Found" },
                    HttpStatusCode.Forbidden => new() { IsSuccess = false, Message = "Access Denided" },
                    HttpStatusCode.Unauthorized => new() { IsSuccess = false, Message = "Unauthorized" },
                    HttpStatusCode.InternalServerError => new() { IsSuccess = false, Message = "InternalServerError" },
                    _ => JsonConvert.DeserializeObject<ResponseDto>(await response.Content.ReadAsStringAsync()),
                };
            }
            catch(Exception ex)
            {
                return new ResponseDto
                {
                    Message = ex.Message,
                    IsSuccess = false
                };
            }

        }
    }
}
