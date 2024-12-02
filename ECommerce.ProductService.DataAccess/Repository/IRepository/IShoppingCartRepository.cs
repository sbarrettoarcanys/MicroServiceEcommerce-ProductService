using ECommerce.ProductService.DataAccess.Data;
using ECommerce.ProductService.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.ProductService.DataAccess.Repository.IRepository
{
    public interface IShoppingCartRepository : IRepository<ShoppingCartModel>
    {
        void Update(ShoppingCartModel shoppingCartModel);
        void Delete(ShoppingCartModel shoppingCartModel);
    }
}
