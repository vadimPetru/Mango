using Mango.Web.Models;
using Mango.Web.Services.Interfaces;
using Mango.Web.Utils;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace Mango.Web.Services.Implementation
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ResponseDto?> SendAsync(RequestDto requestDto)
        {
            try
            {

            
            HttpClient client = _httpClientFactory.CreateClient("MangoAPI");
            HttpRequestMessage message = new();
            message.Headers.Add("Accept", "application/json");
            //token 

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
                    HttpStatusCode.Forbidden => new() { IsSuccess = false, Message = "Forbidden" },
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
