using ECommerce.ProductService.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.ProductService.BusinessLogic.IManagers
{
    public interface IShoppingCartManager
    {
        List<ShoppingCartViewModel> GetAll();
        ShoppingCartViewModel Get(int id);
        int Add(CreateShoppingCartViewModel createShoppingCartViewModel);
        int Update(ShoppingCartViewModel shoppingCartViewModel);
        void Delete(int id);
        ShoppingCartViewModel Get(int productId, string applicationUserId);
        List<ShoppingCartViewModel> GetAll(string applicationUserId);
        ShoppingCartDetailsViewModel GetShoppingCartDetails(string applicationUserId);
    }
}
