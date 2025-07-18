using ProductCatalog.Entities.DTOs;
using ProductCatalog.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Business.Abstract
{
    public interface IProductService
    {
        Task<List<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task AddAsync(ProductCreateDto dto);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Product product);
    }
}
