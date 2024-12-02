using ECommerce.ProductService.BusinessLogic.IManagers;
using ECommerce.ProductService.DataAccess.ModelMappings;
using ECommerce.ProductService.DataAccess.Repository;
using ECommerce.ProductService.DataAccess.Repository.IRepository;
using ECommerce.ProductService.Models.Models;
using ECommerce.ProductService.Models.ViewModels;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Manage.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.ProductService.BusinessLogic.Managers
{
    public class ProductCategoryManager : IProductCategoryManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryManager _categoryManager;

        public ProductCategoryManager(IUnitOfWork unitOfWork, ICategoryManager categoryManager)
        {
            _unitOfWork = unitOfWork;
            _categoryManager = categoryManager;
        }

        public List<ProductCategoryViewModel> CreateProductCategoryViewModels(int productId, IEnumerable<int> categoryIds)
        {
            List<ProductCategoryViewModel> productCategories = new List<ProductCategoryViewModel>();
            ProductViewModel productViewModel = GetProduct(productId);

            foreach (var categoryId in categoryIds)
            {
                ProductCategoryViewModel productCategoryViewModel = new()
                {
                    CategoryId = categoryId,
                    CreateDate = DateTime.Now,
                    IsActive = true,
                    ProductId = productId,
                    
                };

                productCategories.Add(productCategoryViewModel);
            }

            return productCategories;
        }

        private ProductViewModel GetProduct(int productId)
        {
            ProductModel productModel = _unitOfWork._productRepository.GetAllProducts(x => x.Id == productId).First();

            ProductViewModel productViewModel = ProductMappings.ProductModelToProductViewModel.Compile().Invoke(productModel);
            return productViewModel;
        }
    }
}
