using Microsoft.EntityFrameworkCore;
using ProductCatalog.DataAccess.Abstract;
using ProductCatalog.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public readonly ProductCatalogDbContext _context;
        public EfProductDal(ProductCatalogDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product is not null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task UpdateAsync(Product product)
        {
            var entity = await _context.Products.FindAsync(product.Id);

            if (entity is null) return;

            entity.Name = product.Name;
            entity.Price = product.Price;
            entity.Stock = product.Stock;

            await _context.SaveChangesAsync();
        }
    }
}
