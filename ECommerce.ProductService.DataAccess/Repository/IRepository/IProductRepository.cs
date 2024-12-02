using ECommerce.ProductService.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.ProductService.DataAccess.Repository.IRepository
{
    public interface IProductRepository : IRepository<ProductModel>
    {
        void Update(ProductModel productModel);
        void Delete(ProductModel productModel);
        List<ProductModel> GetAllProducts(Expression<Func<ProductModel, bool>>? filter);
        void DeleteProductCategories(ProductModel productModel);
    }
}
