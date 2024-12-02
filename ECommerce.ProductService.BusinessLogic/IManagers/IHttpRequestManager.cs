

using ECommerce.ProductService.Models.ViewModels;

namespace ECommerce.ProductService.BusinessLogic.IManagers
{
    public interface IHttpRequestManager
    {
        Task<ResponseViewModel?> SendAsync(HttpRequestViewModel requestDto, bool withBearer = true);
    }
}
