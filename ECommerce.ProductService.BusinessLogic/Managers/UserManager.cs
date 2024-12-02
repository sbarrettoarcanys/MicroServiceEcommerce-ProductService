using ECommerce.ProductService.BusinessLogic.IManagers;
using ECommerce.ProductService.DataAccess.ModelMappings;
using ECommerce.ProductService.DataAccess.Repository.IRepository;
using ECommerce.ProductService.Models.Models;
using ECommerce.ProductService.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.ProductService.BusinessLogic.Managers
{
    public class UserManager : IUserManager
    {

        private readonly IUnitOfWork _unitOfWork;

        public UserManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int Add(RegistrationRequestViewModel registrationRequestViewModel)
        {
            UserModel userModel = UserMappings.RegistrationViewModelToUserModel.Compile().Invoke(registrationRequestViewModel);
            userModel.CreateDate = DateTime.Now;
            userModel.IsActive = true;

            _unitOfWork._userRepository.Add(userModel);
            _unitOfWork.Save();

            return userModel.Id;
        }

        public int Add(UserViewModel userViewModel)
        {
            UserModel userModel = UserMappings.UserViewModelToUserModel.Compile().Invoke(userViewModel);
            userModel.CreateDate = DateTime.Now;
            userModel.IsActive = true;

            _unitOfWork._userRepository.Add(userModel);
            _unitOfWork.Save();

            return userModel.Id;
        }

        public UserViewModel GetUser(string Id)
        {
            UserModel userModel = _unitOfWork._userRepository.Get(x => x.ExternalId == Id);
            if (userModel != null)
            {
                UserViewModel userViewModel = UserMappings.UserModelToUserViewModel.Compile().Invoke(userModel);
                return userViewModel;
            }

            return null;
        }

        public List<UserViewModel> GetUsers()
        {
            List<UserViewModel> users = _unitOfWork._userRepository.GetAll(null)
                                                     .AsQueryable()
                                                     .Select(UserMappings.UserModelToUserViewModel)
                                                     .ToList() ?? new List<UserViewModel>();
            return users;
        }

    }
}
