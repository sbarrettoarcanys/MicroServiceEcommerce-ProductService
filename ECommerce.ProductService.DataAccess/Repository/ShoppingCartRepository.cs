using ECommerce.ProductService.DataAccess.Data;
using ECommerce.ProductService.DataAccess.Repository.IRepository;
using ECommerce.ProductService.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.ProductService.DataAccess.Repository
{
    public class ShoppingCartRepository: Repository<ShoppingCartModel>, IShoppingCartRepository
    {
        private ApplicationDbContext _dbContext;
        public ShoppingCartRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update(ShoppingCartModel shoppingCartModel)
        {
            shoppingCartModel.UpdateDate = DateTime.Now;

            _dbContext.Shoppingcarts.Update(shoppingCartModel);
        }

        public void Delete(ShoppingCartModel shoppingCartModel)
        {
            _dbContext.Shoppingcarts.Remove(shoppingCartModel);
        }
    }
}
