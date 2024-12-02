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
    public static class CategoryMappings
    {
        public static readonly Expression<Func<CategoryModel, CategoryViewModel>> CategoryModelToCategoryViewModel = x =>
        new CategoryViewModel
        {
            Id = x.Id,
            Name = x.Name,
            DisplayOrder = x.DisplayOrder,
            IsActive = x.IsActive,
            CreateDate = x.CreateDate,
            UpdateDate = x.UpdateDate,
        };


        public static readonly Expression<Func<CategoryViewModel, CategoryModel>> CategoryViewModelToCategoryModel = x => new CategoryModel
        {
            Id = x.Id,
            Name = x.Name,
            DisplayOrder = x.DisplayOrder,
            IsActive = x.IsActive,
            CreateDate = x.CreateDate,
            UpdateDate = x.UpdateDate,
        };

        public static readonly Expression<Func<CreateCategoryViewModel, CategoryModel>> CreateCategoryViewModelToModel = x => new CategoryModel
        {
            Name = x.Name,
            DisplayOrder = x.DisplayOrder
        };

        public static readonly Expression<Func<UpdateCategoryViewModel, CategoryModel>> UpdateCategoryViewModelToModel = x => new CategoryModel
        {
            Id = x.Id,
            Name = x.Name,
            DisplayOrder = x.DisplayOrder,
            CreateDate = x.CreateDate

        };
    }
}
