
using ECommerce.ProductService.BusinessLogic.IManagers;
using ECommerce.ProductService.Utility;
using Microsoft.AspNetCore.Http;

namespace ECommerce.ProductService.BusinessLogic.Managers
{
    public class TokenProviderManager : ITokenProviderManager
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public TokenProviderManager(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }


        public void ClearToken()
        {
            _contextAccessor.HttpContext?.Response.Cookies.Delete(ConstantValues.TokenCookie);
        }

        public string? GetToken()
        {
            string? token = null;
            bool? hasToken = _contextAccessor.HttpContext?.Request.Cookies.TryGetValue(ConstantValues.TokenCookie, out token);
            return hasToken is true ? token : null;
        }

        public void SetToken(string token)
        {
            _contextAccessor.HttpContext?.Response.Cookies.Append(ConstantValues.TokenCookie, token);
        }
    }
}
