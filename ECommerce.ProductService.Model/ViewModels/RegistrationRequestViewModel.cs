namespace ECommerce.ProductService.Models.ViewModels
{
    public class RegistrationRequestViewModel
    {
        public string? Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string Password { get; set; }
        public string? Role { get; set; }
        public string? ErrorMessage { get; set; }
        public string? Event { get; set; }

    }

}
