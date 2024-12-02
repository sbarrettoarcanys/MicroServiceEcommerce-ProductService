namespace ECommerce.ProductService.BusinessLogic.IManagers
{
    public interface ITokenProviderManager
    {

        void SetToken(string token);
        string? GetToken();
        void ClearToken();
    }
}
