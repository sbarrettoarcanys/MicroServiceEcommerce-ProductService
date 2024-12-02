using ECommerce.ProductService.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.ProductService.DataAccess.Repository.IRepository
{
    public interface IUserRepository : IRepository<UserModel>
    {
        void Update(UserModel userModel);
        void Delete(UserModel userModel);
    }
}
