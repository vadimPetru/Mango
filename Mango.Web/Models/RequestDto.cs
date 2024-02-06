namespace Mango.Web.Models
{
    public class RequestDto
    {
        public ApiType RequestType { get; set;} = ApiType.GET;
        public string Url { get; set;}
        public object Data { get; set;}
        public string AccessToken { get; set;}
    }
}
    