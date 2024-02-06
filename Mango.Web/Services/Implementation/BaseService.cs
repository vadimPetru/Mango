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

            switch (requestDto.ApiTypes)
            {
                case ApiType.POST:
                    message.Method = HttpMethod.Post;
                    break;
                case ApiType.DELETE:
                    message.Method = HttpMethod.Delete;
                    break;
                case ApiType.PUT:
                    message.Method = HttpMethod.Put;
                    break;
                default:
                    message.Method = HttpMethod.Get;
                    break;
            }

            response = await client.SendAsync(message);


            switch (response.StatusCode) {

                case HttpStatusCode.NotFound:
                    return new() { IsSuccess = false, Message = "Not Found" };
                case HttpStatusCode.Forbidden:
                    return new() { IsSuccess = false, Message = "Forbidden" };
                case HttpStatusCode.Unauthorized:
                    return new() { IsSuccess = false, Message = "Unauthorized" };
                case HttpStatusCode.InternalServerError:
                    return new() { IsSuccess = false, Message = "InternalServerError" };
                default:
                    return JsonConvert.DeserializeObject<ResponseDto>(await response.Content.ReadAsStringAsync());
                    
            }
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
