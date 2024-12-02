using ECommerce.ProductService.Models.Models;
using ECommerce.ProductService.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.ProductService.DataAccess.ModelMappings
{
    public static class ShoppingCartMappings
    {
        public static readonly Expression<Func<ShoppingCartViewModel, ShoppingCartModel>> ShoppingCartViewModelToShoppingCartModel = x =>
        new ShoppingCartModel
        {
            Id = x.Id,
            Count = x.Count,
            ProductId = x.ProductId,
            UserId = x.UserId,
            CreateDate = x.CreateDate,
            IsActive = x.IsActive,

        };

        public static readonly Expression<Func<CreateShoppingCartViewModel, ShoppingCartModel>> CreateShoppingCartViewModelToShoppingCartModel = x =>
        new ShoppingCartModel
        {
            Count = x.Count,
            ProductId = x.ProductId,
            UserId = x.UserId,
        };

        public static readonly Expression<Func<ShoppingCartModel, ShoppingCartViewModel>> ShoppingCartModelToShoppingCartViewModel = x =>
        new ShoppingCartViewModel
        {
            Id = x.Id,
            Count = x.Count,
            ProductId = x.ProductId,
            UserId = x.UserId,
            CreateDate = x.CreateDate,
            IsActive = x.IsActive,
            UpdateDate = x.UpdateDate,
            Price = x.Product.DiscountedPrice?? x.Product.Price,
            ExternalId = x.User.ExternalId,
            
            Product = new ProductViewModel
            {
                Id = x.Product.Id,
                Code = x.Product.Code,
                Description = x.Product.Description,
                DiscountedPrice = x.Product.DiscountedPrice,
                Name = x.Product.Name,
                Price = x.Product.Price,
                IsActive = x.Product.IsActive,
                CreateDate = x.Product.CreateDate,
                UpdateDate = x.Product.UpdateDate,
            },
            
        };
    }
}
