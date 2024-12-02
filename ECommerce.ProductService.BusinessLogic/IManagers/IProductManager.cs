using ECommerce.ProductService.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.ProductService.BusinessLogic.IManagers
{
    public interface IProductManager
    {
        List<ProductViewModel> GetAll();
        List<ProductViewModel> GetAllActive();
        ProductViewModel Get(int id);
        int Add(CreateProductViewModel createProductViewModel);
        int Update(UpdateProductViewModel updateProductViewModel);
        void Delete(int id);
        List<ProductViewModel> GetAllActive(string searchText);
    }
}
