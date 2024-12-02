using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.ProductService.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {

        ICategoryRepository _categoryRepository { get; }
        IProductCategoryRepository _productCategoryRepository { get; }
        IProductRepository _productRepository { get; }
        IProductImageRepository _productImageRepository { get; }
        IShoppingCartRepository _shoppingCartRepository { get; }
        IUserRepository _userRepository { get; }
        void Save();
    }
}
