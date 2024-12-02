using ECommerce.ProductService.DataAccess.Data;
using ECommerce.ProductService.DataAccess.Repository.IRepository;
using ECommerce.ProductService.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.ProductService.DataAccess.Repository
{
    public class UserRepository : Repository<UserModel>, IUserRepository
    {
        private ApplicationDbContext _dbContext;
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update(UserModel userModel)
        {
            userModel.UpdateDate = DateTime.Now;
            _dbContext.Users.Update(userModel);
        }

        public void Delete(UserModel userModel)
        {
            userModel.IsActive = false;
            Update(userModel);
        }
    }
}
