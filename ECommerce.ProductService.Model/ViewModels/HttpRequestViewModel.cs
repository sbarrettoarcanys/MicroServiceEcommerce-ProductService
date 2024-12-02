using static ECommerce.ProductService.Utility.ConstantValues;

namespace ECommerce.ProductService.Models.ViewModels
{
    public class HttpRequestViewModel
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }

        public ContentType ContentType { get; set; } = ContentType.Json;
    }
}
