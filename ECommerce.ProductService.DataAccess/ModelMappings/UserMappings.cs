using ECommerce.ProductService.Models.Models;
using ECommerce.ProductService.Models.ViewModels;
using System.Linq.Expressions;

namespace ECommerce.ProductService.DataAccess.ModelMappings
{
    public static class UserMappings
    {

        public static readonly Expression<Func<RegistrationRequestViewModel, UserModel>> RegistrationViewModelToUserModel = x => new UserModel
        {
            City = x.City,
            Email = x.Email,
            ExternalId = x.Id,
            PhoneNumber = x.PhoneNumber,
            StreetAddress = x.StreetAddress,
            Name = x.Name,
        };

        public static readonly Expression<Func<UserModel, UserViewModel>> UserModelToUserViewModel = x => new UserViewModel
        {
            City = x.City,
            Email = x.Email,
            ExternalId = x.ExternalId,
            PhoneNumber = x.PhoneNumber,
            StreetAddress = x.StreetAddress,
            Name = x.Name,
            Id = x.Id,
            
        };

        public static readonly Expression<Func<UserViewModel, UserModel>> UserViewModelToUserModel = x => new UserModel
        {
            City = x.City,
            Email = x.Email,
            ExternalId = x.ExternalId,
            PhoneNumber = x.PhoneNumber,
            StreetAddress = x.StreetAddress,
            Name = x.Name,
            Id = x.Id,
            
        };
    }
}
