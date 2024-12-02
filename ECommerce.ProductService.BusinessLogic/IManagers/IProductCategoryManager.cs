using ECommerce.ProductService.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.ProductService.BusinessLogic.IManagers
{
    public interface IProductCategoryManager
    {
        List<ProductCategoryViewModel> CreateProductCategoryViewModels(int productId, IEnumerable<int> categoryIds);

    }
}
