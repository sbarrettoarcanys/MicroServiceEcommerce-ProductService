

using ECommerce.ProductService.BusinessLogic.IManagers;
using ECommerce.ProductService.Models.ViewModels;
using ECommerce.ProductService.Utility;

namespace ECommerce.ProductService.BusinessLogic.Managers
{
    public class AuthManager : IAuthManager
    {
        private readonly IHttpRequestManager _httpRequestManager;
        public AuthManager(IHttpRequestManager httpRequestManager)
        {
            _httpRequestManager = httpRequestManager;
        }

        public async Task<ResponseViewModel?> LoginAsync(LoginRequestViewModel loginRequestDto)
        {
            return await _httpRequestManager.SendAsync(new HttpRequestViewModel()
            {
                ApiType = ConstantValues.ApiType.POST,
                Data = loginRequestDto,
                Url = ConstantValues.AuthAPIBase + "/api/user/login"
            }, withBearer: false);
        }

        public async Task<ResponseViewModel?> RegisterAsync(RegistrationRequestViewModel registrationRequestViewModel)
        {
            return await _httpRequestManager.SendAsync(new HttpRequestViewModel()
            {
                ApiType = ConstantValues.ApiType.POST,
                Data = registrationRequestViewModel,
                Url = ConstantValues.AuthAPIBase + "/api/user/register"
            }, withBearer: false);
        }
    }
}
