using ECommerce.ProductService.BusinessLogic.IManagers;
using ECommerce.ProductService.DataAccess.ModelMappings;
using ECommerce.ProductService.DataAccess.Repository.IRepository;
using ECommerce.ProductService.Models.Models;
using ECommerce.ProductService.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.ProductService.BusinessLogic.Managers
{
    public class ShoppingCartManager : IShoppingCartManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ICategoryManager _categoryManager;
        private readonly IUserManager _userManager;
        private readonly IProductManager _productManager;

        public ShoppingCartManager(IUnitOfWork unitOfWork,
            IWebHostEnvironment webHostEnvironment,
            ICategoryManager categoryManager,
            IUserManager? userManager,
            IProductManager productManager)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
            _categoryManager = categoryManager;

            _productManager = productManager;

            _userManager = userManager;
        }

        public int Add(CreateShoppingCartViewModel createShoppingCartViewModel)
        {
            ShoppingCartViewModel existingCart = Get(createShoppingCartViewModel.ProductId, createShoppingCartViewModel.ExternalId);
            ShoppingCartModel shoppingCartModel = new ShoppingCartModel();
            if (existingCart != null)
            {
                //shopping cart exists
                existingCart.Count += createShoppingCartViewModel.Count;
                shoppingCartModel = ShoppingCartMappings.ShoppingCartViewModelToShoppingCartModel.Compile().Invoke(existingCart);

                shoppingCartModel.IsActive = true;
                _unitOfWork._shoppingCartRepository.Update(shoppingCartModel);
                _unitOfWork.Save();
            }
            else
            {
                //add cart record
                createShoppingCartViewModel.UserId = _userManager.GetUser(createShoppingCartViewModel.ExternalId).Id;
                shoppingCartModel = ShoppingCartMappings.CreateShoppingCartViewModelToShoppingCartModel.Compile().Invoke(createShoppingCartViewModel);
                shoppingCartModel.IsActive = true;
                shoppingCartModel.CreateDate = DateTime.Now;

                _unitOfWork._shoppingCartRepository.Add(shoppingCartModel);
                _unitOfWork.Save();
            }

            return shoppingCartModel.Id;
        }

        public ShoppingCartViewModel Get(int id)
        {
            ShoppingCartModel shoppingCartModel = _unitOfWork._shoppingCartRepository.Get(x => x.Id == id, "Product,User");
            var shoppingCartViewModel = ShoppingCartMappings.ShoppingCartModelToShoppingCartViewModel.Compile().Invoke(shoppingCartModel);
            return shoppingCartViewModel;
        }

        public ShoppingCartViewModel Get(int productId, string applicationUserId)
        {
            ShoppingCartModel shoppingCartModel = _unitOfWork._shoppingCartRepository
                .Get(x => x.ProductId == productId && x.User.ExternalId == applicationUserId, "Product,User");
            if (shoppingCartModel != null)
            {
                var shoppingCartViewModel = ShoppingCartMappings.ShoppingCartModelToShoppingCartViewModel.Compile().Invoke(shoppingCartModel);
                return shoppingCartViewModel; 
            }
            return null;
        }

        public List<ShoppingCartViewModel> GetAll()
        {
            List<ShoppingCartViewModel> shoppingCartViewModels = _unitOfWork._shoppingCartRepository.GetAll(null, "Product,User")
                .AsQueryable()
                .Select(ShoppingCartMappings.ShoppingCartModelToShoppingCartViewModel)
                .ToList();
            return shoppingCartViewModels;
        }
        public List<ShoppingCartViewModel> GetAll(string externalId)
        {
            List<ShoppingCartViewModel> shoppingCartViewModels = _unitOfWork._shoppingCartRepository
                .GetAll(x => x.User.ExternalId == externalId, "Product,User")
                .AsQueryable()
                ?.Select(ShoppingCartMappings.ShoppingCartModelToShoppingCartViewModel)
                .ToList() ?? new List<ShoppingCartViewModel>();
            return shoppingCartViewModels;
        }

        public int Update(ShoppingCartViewModel productViewModel)
        {
            var productModel = ShoppingCartMappings.ShoppingCartViewModelToShoppingCartModel.Compile().Invoke(productViewModel);
            _unitOfWork._shoppingCartRepository.Update(productModel);
            _unitOfWork.Save();

            return productModel.Id;
        }

        public void Delete(int id)
        {
            ShoppingCartModel shoppingCartModel = _unitOfWork._shoppingCartRepository.Get(x => x.Id == id, "Product,User");
            _unitOfWork._shoppingCartRepository.Delete(shoppingCartModel);
            _unitOfWork.Save();
        }

        #region ShoppingCart details
        public ShoppingCartDetailsViewModel GetShoppingCartDetails(string applicationUserId)
        {
            List<ShoppingCartViewModel> shoppingCartViewModels = GetAll(applicationUserId);
            ShoppingCartDetailsViewModel shoppingCartDetailsViewModel = new ShoppingCartDetailsViewModel()
            {
                ShoppingCartViewModels = shoppingCartViewModels,
            };
            foreach (ShoppingCartViewModel cart in shoppingCartDetailsViewModel.ShoppingCartViewModels)
            {
                cart.Price = cart.Product.DiscountedPrice ?? cart.Product.Price;
                shoppingCartDetailsViewModel.OrderTotal += (cart.Price * cart.Count);

                cart.Product = _productManager.Get(cart.ProductId);

            }

            return shoppingCartDetailsViewModel;

        }
        #endregion
    }
}
