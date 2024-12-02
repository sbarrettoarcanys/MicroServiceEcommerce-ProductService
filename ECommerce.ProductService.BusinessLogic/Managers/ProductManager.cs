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
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.ProductService.BusinessLogic.Managers
{
    public class ProductManager : IProductManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ICategoryManager _categoryManager;
        private readonly IProductCategoryManager _productCategoryManager;
        private readonly IProductImageManager _productImageManager;

        public ProductManager(IUnitOfWork unitOfWork,
            IWebHostEnvironment webHostEnvironment,
            IProductCategoryManager productCategoryManager,
            IProductImageManager productImageManager,
            ICategoryManager categoryManager)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
            _categoryManager = categoryManager;
            _productCategoryManager = productCategoryManager;
            _productImageManager = productImageManager;
        }

        public List<ProductViewModel> GetAll()
        {
            List<ProductViewModel> products = _unitOfWork._productRepository.GetAllProducts(null)
                                                     .AsQueryable()
                                                     .Select(ProductMappings.ProductModelToProductViewModel)
                                                     .ToList();

            return products;
        }

        public List<ProductViewModel> GetAllActive()
        {
            List<ProductViewModel> products = _unitOfWork._productRepository.GetAllProducts(x => x.IsActive)
                                                     .AsQueryable()
                                                     .Select(ProductMappings.ProductModelToProductViewModel)
                                                     .ToList();

            return products;
        }
        public List<ProductViewModel> GetAllActive(string searchText)
        {
            List<ProductViewModel> products = _unitOfWork._productRepository
                .GetAllProducts(x => x.IsActive &&
                (x.Name.Contains(searchText) || x.Description.Contains(searchText) || x.Code.Contains(searchText)
                    || x.ProductCategories.Any(y => y.Category.Name.Contains(searchText)))

                )
                                                     .AsQueryable()
                                                     .Select(ProductMappings.ProductModelToProductViewModel)
                                                     .ToList();

            return products;
        }


        public ProductViewModel Get(int id)
        {
            ProductModel productModel = _unitOfWork._productRepository.GetAllProducts(x => x.Id == id).First();

            if (productModel != null)
            {

                ProductViewModel productViewModel = ProductMappings.ProductModelToProductViewModel.Compile().Invoke(productModel);
                return productViewModel;
            }

            return null;


        }

        public int Add(CreateProductViewModel createProductViewModel)
        {
            ProductModel productModel = ProductMappings.CreateProductViewModelToProductModel.Compile().Invoke(createProductViewModel);
            productModel.CreateDate = DateTime.Now;
            productModel.IsActive = true;

            _unitOfWork._productRepository.Add(productModel);
            _unitOfWork.Save();


            if (createProductViewModel.Files != null && createProductViewModel.Files.Count > 0)
            {
                List<ProductImageViewModel> productImageViewModels = _productImageManager
                    .CreateProductImageViewModels(productModel.Id, createProductViewModel.Files);
                _productImageManager.AddBulk(productImageViewModels);
                _unitOfWork.Save();

            }

            if (createProductViewModel.CategoryIds != null && createProductViewModel.CategoryIds.Count() > 0)
            {
                List<ProductCategoryViewModel> productCategoryViewModels = _productCategoryManager
                    .CreateProductCategoryViewModels(productModel.Id, createProductViewModel.CategoryIds);

                List<ProductCategoryModel> productCategoryModels = productCategoryViewModels.AsQueryable()
                    .Select(ProductCategoryMappings.ProductCategoryViewModelToProductCategoryModel)
                    .ToList();

                productModel.ProductCategories.AddRange(productCategoryModels);
                _unitOfWork.Save();
            }

            return productModel.Id;
        }

        public int Update(UpdateProductViewModel updateProductViewModel)
        {
            ProductModel productModel = ProductMappings.UpdateProductViewModelToProductModel.Compile().Invoke(updateProductViewModel);
            _unitOfWork._productRepository.Update(productModel);
            _unitOfWork.Save();

            if (updateProductViewModel.Files != null && updateProductViewModel.Files.Count > 0)
            {
                var productImageViewModels = _productImageManager
                    .CreateProductImageViewModels(updateProductViewModel.Id, updateProductViewModel.Files);
                _productImageManager.AddBulk(productImageViewModels);
                _unitOfWork.Save();

            }

            if (updateProductViewModel.CategoryIds != null && updateProductViewModel.CategoryIds.Count() > 0)
            {
                List<ProductCategoryViewModel> productCategoryViewModels = _productCategoryManager
                           .CreateProductCategoryViewModels(updateProductViewModel.Id, updateProductViewModel.CategoryIds);

                _unitOfWork._productCategoryRepository.SaveList<ProductCategoryViewModel>(
                   getAllFilter: x => x.ProductId == updateProductViewModel.Id,
                   viewModelList: productCategoryViewModels,
                   compareFilter: (model, viewModel) => model.ProductId == updateProductViewModel.Id && model.CategoryId == viewModel.CategoryId,
                   viewModelToModelExpression: x => ProductCategoryMappings.ProductCategoryViewModelToProductCategoryModel.Compile().Invoke(x)

                );

                _unitOfWork.Save();
            }

            return productModel.Id;
        }


        public void Delete(int id)
        {
            ProductModel productModel = _unitOfWork._productRepository.Get(x => x.IsActive && x.Id == id);
            _unitOfWork._productRepository.Delete(productModel);
            _unitOfWork.Save();

        }

    }
}
