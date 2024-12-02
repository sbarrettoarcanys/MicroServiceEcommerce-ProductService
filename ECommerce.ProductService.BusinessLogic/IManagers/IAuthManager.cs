using ECommerce.ProductService.Models.ViewModels;

namespace ECommerce.ProductService.BusinessLogic.IManagers
{
    public interface IAuthManager
    {
        Task<ResponseViewModel?> LoginAsync(LoginRequestViewModel loginRequestDto);
        Task<ResponseViewModel?> RegisterAsync(RegistrationRequestViewModel registrationRequestDto);
    }
}
