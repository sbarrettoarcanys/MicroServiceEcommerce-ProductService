﻿using ECommerce.ProductService.DataAccess.Data;
using ECommerce.ProductService.DataAccess.Repository.IRepository;
using ECommerce.ProductService.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.ProductService.DataAccess.Repository
{
    public class ProductImageRepository : Repository<ProductImageModel>, IProductImageRepository
    {
        private ApplicationDbContext _dbContext;
        public ProductImageRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public void Delete(ProductImageModel productImageModel)
        {
            _dbContext.Remove(productImageModel);
        }

        public void Update(ProductImageModel productImageModel)
        {
            productImageModel.UpdateDate = DateTime.Now;
            _dbContext.Update(productImageModel);
        }

        public void AddBulk(List<ProductImageModel> productImageModels)
        {
            _dbContext.AddRange(productImageModels);
        }
    }
}
