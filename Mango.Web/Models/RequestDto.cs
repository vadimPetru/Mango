using Mango.Web.Utils;

namespace Mango.Web.Models
{
    public class RequestDto
    {
        public ApiType ApiTypes { get; set;} = ApiType.GET;
        public string Url { get; set;}
        public object Data { get; set;}
        public string AccessToken { get; set;}
    }
}
    