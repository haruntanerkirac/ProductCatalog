using Microsoft.EntityFrameworkCore;
using ProductCatalog.Business.Abstract;
using ProductCatalog.DataAccess;
using ProductCatalog.DataAccess.Abstract;
using ProductCatalog.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public async Task AddAsync(Product product) => await _productDal.AddAsync(product);

        public async Task DeleteAsync(Product product) => await _productDal.DeleteAsync(product);

        public async Task<List<Product>> GetAllAsync() => await _productDal.GetAllAsync();

        public async Task<Product?> GetByIdAsync(int id) => await _productDal.GetByIdAsync(id);

        public async Task UpdateAsync(Product product) => await _productDal.UpdateAsync(product);
    }
}
