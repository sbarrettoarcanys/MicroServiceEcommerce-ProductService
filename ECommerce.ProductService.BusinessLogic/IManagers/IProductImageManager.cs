using ECommerce.ProductService.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.ProductService.BusinessLogic.IManagers
{
    public interface IProductImageManager
    {
        int Delete(int id);

        List<ProductImageViewModel> CreateProductImageViewModels(int productId, List<IFormFile> files);
        void AddBulk(List<ProductImageViewModel> productViewModels);

        List<ProductImageViewModel> GetAll(int productId);
    }
}
