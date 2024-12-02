using ECommerce.ProductService.BusinessLogic.IManagers;
using ECommerce.ProductService.DataAccess.ModelMappings;
using ECommerce.ProductService.DataAccess.Repository.IRepository;
using ECommerce.ProductService.Models.Models;
using ECommerce.ProductService.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.ProductService.BusinessLogic.Managers
{
    public class ProductImageManager : IProductImageManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductImageManager(IUnitOfWork unitOfWork,
            IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public void AddBulk(List<ProductImageViewModel> productViewModels)
        {
            List<ProductImageModel> productImageModels = productViewModels
                .AsQueryable()
                .Select(ProductImageMappings.ProductImageViewModelToProductImageModel)
                .ToList();

            _unitOfWork._productImageRepository.AddBulk(productImageModels);
        }

        public List<ProductImageViewModel> CreateProductImageViewModels(int productId, List<IFormFile> files)
        {

            List<ProductImageViewModel> productImages = new List<ProductImageViewModel>();
            string wwwRootPath = _webHostEnvironment.WebRootPath;

            ProductViewModel productViewModel = GetProduct(productId);

            foreach (IFormFile file in files)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string productPath = @"images/products/product-" + productId;
                string finalPath = Path.Combine(wwwRootPath, productPath).Replace(@"\", "/");

                if (!Directory.Exists(finalPath))
                    Directory.CreateDirectory(finalPath);

                using (var fileStream = new FileStream(Path.Combine(finalPath, fileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                ProductImageViewModel productImage = new()
                {
                    ImageUrl = @"/" + productPath + @"/" + fileName,
                    ProductId = productId,
                    CreateDate = DateTime.Now,
                    IsActive = true,
                    ProductViewModel = productViewModel,

                };

                productImages.Add(productImage);

            }

            return productImages;
        }
        public int Delete(int id)
        {
            ProductImageModel imageToBeDeleted = _unitOfWork._productImageRepository.Get(u => u.Id == id);
            if (imageToBeDeleted != null)
            {
                if (!string.IsNullOrEmpty(imageToBeDeleted.ImageUrl))
                {
                    var oldImagePath =
                                   Path.Combine(_webHostEnvironment.WebRootPath,
                                   imageToBeDeleted.ImageUrl.TrimStart('\\'));

                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                _unitOfWork._productImageRepository.Delete(imageToBeDeleted);
                _unitOfWork.Save();
                return imageToBeDeleted.ProductId;
            }
            else
            {
                return 0;
            }
        }

        private ProductViewModel GetProduct(int productId)
        {
            ProductModel productModel = _unitOfWork._productRepository.GetAllProducts(x => x.Id == productId).First();
            ProductViewModel productViewModel = ProductMappings.ProductModelToProductViewModel.Compile().Invoke(productModel);
            return productViewModel;
        }

        public List<ProductImageViewModel> GetAll(int productId)
        {
            IEnumerable<ProductImageModel> productImageModels = _unitOfWork._productImageRepository.GetAll(x => x.ProductId == productId, "Product");
            List<ProductImageViewModel> productImageViewModels = productImageModels.AsQueryable()
                .Select(ProductImageMappings.ProductImageModelToProductImageViewModel)
                .ToList();

            return productImageViewModels;
        }
    }
}
