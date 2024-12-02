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
    public class CategoryManager : ICategoryManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<CategoryViewModel> GetAllActive()
        {
            List<CategoryViewModel> categories = _unitOfWork._categoryRepository.GetAll(x => x.IsActive)
                                  .AsQueryable()
                                  .Select(CategoryMappings.CategoryModelToCategoryViewModel)
                                  .ToList();

            return categories;
        }

        public List<CategoryViewModel> GetAll()
        {
            List<CategoryViewModel> categories = _unitOfWork._categoryRepository.GetAll(null)
                                  .AsQueryable()
                                  .Select(CategoryMappings.CategoryModelToCategoryViewModel)
                                  .ToList();

            return categories;
        }

        public CategoryViewModel Get(int id)
        {
            CategoryModel categoryModel = _unitOfWork._categoryRepository.Get(x => x.Id == id);
            if (categoryModel != null)
            {
                CategoryViewModel categoryViewModel = CategoryMappings.CategoryModelToCategoryViewModel.Compile().Invoke(categoryModel);

                return categoryViewModel; 
            }

            return null;
        }

        public int Add(CreateCategoryViewModel categoryCreateViewModel)
        {
            CategoryModel categoryModel = CategoryMappings.CreateCategoryViewModelToModel.Compile().Invoke(categoryCreateViewModel);
            categoryModel.CreateDate = DateTime.Now;
            categoryModel.IsActive = true;

            _unitOfWork._categoryRepository.Add(categoryModel);
            _unitOfWork.Save();

            return categoryModel.Id;
        }

        public int Update(UpdateCategoryViewModel updateCategoryViewModel)
        {
            CategoryModel categoryModel = CategoryMappings.UpdateCategoryViewModelToModel.Compile().Invoke(updateCategoryViewModel);
            _unitOfWork._categoryRepository.Update(categoryModel);
            _unitOfWork.Save();

            return categoryModel.Id;
        }


        public int Delete(int id)
        {
            CategoryModel categoryModel = _unitOfWork._categoryRepository.Get(x => x.IsActive && x.Id == id);
            _unitOfWork._categoryRepository.Delete(categoryModel);
            _unitOfWork.Save();

            return categoryModel.Id;
        }
    }
}
