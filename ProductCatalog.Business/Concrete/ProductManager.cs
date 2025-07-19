using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Business.Abstract;
using ProductCatalog.DataAccess;
using ProductCatalog.DataAccess.Abstract;
using ProductCatalog.Entities.DTOs;
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
        private readonly IMapper _mapper;
        private readonly ILoggerService _logger;

        public ProductManager(IProductDal productDal, IMapper mapper, ILoggerService logger)
        {
            _productDal = productDal;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task AddAsync(ProductCreateDto dto)
        {
            try
            {
                var entity = _mapper.Map<Product>(dto);
                await _productDal.AddAsync(entity);

                _logger.LogInfo($"Yeni ürün eklendi: {entity.Name}");
            }
            catch (Exception ex)
            {
                string message = $"Ürün eklenirken hata : {ex.Message}";
                _logger.LogError(message);
                throw new Exception(message);
            }
            //await _productDal.AddAsync(product);
        } 

        public async Task DeleteAsync(Product product) => await _productDal.DeleteAsync(product);

        public async Task<List<Product>> GetAllAsync() => await _productDal.GetAllAsync();

        public async Task<Product?> GetByIdAsync(int id) => await _productDal.GetByIdAsync(id);

        public async Task UpdateAsync(Product product) => await _productDal.UpdateAsync(product);
    }
}
