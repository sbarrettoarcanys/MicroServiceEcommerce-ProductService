using ECommerce.ProductService.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.ProductService.BusinessLogic.IManagers
{
    public interface IUserManager
    {
        int Add(RegistrationRequestViewModel registrationRequestViewModel);
        UserViewModel GetUser(string Id);
        int Add(UserViewModel userViewModel);
        List<UserViewModel> GetUsers();
    }
}
