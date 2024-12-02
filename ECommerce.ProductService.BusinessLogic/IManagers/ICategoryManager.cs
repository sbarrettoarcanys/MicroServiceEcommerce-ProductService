using ECommerce.ProductService.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.ProductService.BusinessLogic.IManagers
{
    public interface ICategoryManager
    {
        List<CategoryViewModel> GetAllActive();
        List<CategoryViewModel> GetAll();
        CategoryViewModel Get(int id);
        int Add(CreateCategoryViewModel categoryCreateViewModel);
        int Update(UpdateCategoryViewModel updateCategoryViewModel);
        int Delete(int id);
    }
}
