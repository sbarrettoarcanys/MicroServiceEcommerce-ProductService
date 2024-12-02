using ECommerce.ProductService.Models.Models;
using ECommerce.ProductService.Models.ViewModels;
using System.Linq.Expressions;

namespace ECommerce.ProductService.DataAccess.ModelMappings
{
    public static class ProductMappings
    {
        public static readonly Expression<Func<ProductModel, ProductViewModel>> ProductModelToProductViewModel = x =>
        new ProductViewModel
        {
            Id = x.Id,
            Code = x.Code,
            Description = x.Description,
            DiscountedPrice = x.DiscountedPrice,
            Name = x.Name,
            Price = x.Price,
            IsActive = x.IsActive, 
            CreateDate = x.CreateDate,
            UpdateDate = x.UpdateDate,
            ProductImages = x.ProductImages.Where(y => y.IsActive)
                                           .AsQueryable()
                                           .Select(ProductImageMappings.ProductImageModelToProductImageViewModel)
                                           .ToList(),
            ProductCategories = x.ProductCategories.Where(y => y.IsActive)
                                                   .AsQueryable()
                                                   .Select(ProductCategoryMappings.ProductCategoryModelToProductCategoryViewModel)
                                                   .ToList(),
            //CategoryIds = x.ProductCategories.Where(y => y.IsActive).Select(y => y.CategoryId).AsEnumerable(),
        };

        public static readonly Expression<Func<ProductViewModel, ProductModel>> ProductViewModelToProductModel = x =>
        new ProductModel
        {
            Id = x.Id,
            Code = x.Code,
            Description = x.Description,
            DiscountedPrice = x.DiscountedPrice,
            Name = x.Name,
            Price = x.Price,
            IsActive = x.IsActive,
            CreateDate = x.CreateDate,
            UpdateDate = x.UpdateDate,
            ProductImages = x.ProductImages.AsQueryable()
                                           .Select(ProductImageMappings.ProductImageViewModelToProductImageModel)
                                           .ToList() ?? new List<ProductImageModel>(),
            ProductCategories = x.ProductCategories.AsQueryable()
                                                   .Select(ProductCategoryMappings.ProductCategoryViewModelToProductCategoryModel)
                                                   .ToList() ?? new List<ProductCategoryModel>(),
        };

        public static readonly Expression<Func<CreateProductViewModel, ProductModel>> CreateProductViewModelToProductModel = x =>
        new ProductModel
        {
            Code = x.Code,
            Description = x.Description,
            DiscountedPrice = x.DiscountedPrice,
            Name = x.Name,
            Price = x.Price,
            ProductImages =  new List<ProductImageModel>(),
            ProductCategories =  new List<ProductCategoryModel>(),
        };

        public static readonly Expression<Func<UpdateProductViewModel, ProductModel>> UpdateProductViewModelToProductModel = x =>
        new ProductModel
        {
            Id = x.Id,
            Code = x.Code,
            Description = x.Description,
            DiscountedPrice = x.DiscountedPrice,
            Name = x.Name,
            Price = x.Price,
            ProductImages =  new List<ProductImageModel>(),
            ProductCategories =  new List<ProductCategoryModel>(),
            IsActive = x.IsActive,
            CreateDate = x.CreateDate.Value,
        };
    }

    public static class ProductCategoryMappings
    {
        public static readonly Expression<Func<ProductCategoryModel, ProductCategoryViewModel>> ProductCategoryModelToProductCategoryViewModel = x =>
        new ProductCategoryViewModel
        {

            Id = x.Id,
            CategoryId = x.CategoryId,
            IsActive = x.IsActive,
            CreateDate = x.CreateDate,
            UpdateDate = x.UpdateDate,
            ProductId = x.ProductId,
            CategoryViewModel = new CategoryViewModel
            {
                Id = x.Category.Id,
                DisplayOrder = x.Category.DisplayOrder,
                Name = x.Category.Name,
                CreateDate = x.Category.CreateDate,
                UpdateDate = x.Category.UpdateDate,
                IsActive = x.Category.IsActive,
            }
        };

        public static readonly Expression<Func<ProductCategoryViewModel, ProductCategoryModel>> ProductCategoryViewModelToProductCategoryModel = x =>
        new ProductCategoryModel
        {

            Id = x.Id,
            CategoryId = x.CategoryId,
            IsActive = x.IsActive,
            CreateDate = x.CreateDate,
            UpdateDate = x.UpdateDate,
            ProductId = x.ProductId,
        };
    }

    public static class ProductImageMappings
    {
        public static readonly Expression<Func<ProductImageModel, ProductImageViewModel>> ProductImageModelToProductImageViewModel = x =>
        new ProductImageViewModel
        {
            Id = x.Id,
            ProductId = x.ProductId,
            ImageUrl = x.ImageUrl,
            IsActive = x.IsActive,
            CreateDate = x.CreateDate,
            UpdateDate = x.UpdateDate,
        };

        public static readonly Expression<Func<ProductImageViewModel, ProductImageModel>> ProductImageViewModelToProductImageModel = x =>
        new ProductImageModel
        {
            Id = x.Id,
            ProductId = x.ProductId,
            ImageUrl = x.ImageUrl,
            IsActive = x.IsActive,
            CreateDate = x.CreateDate,
            UpdateDate = x.UpdateDate,
        };
    }
}
