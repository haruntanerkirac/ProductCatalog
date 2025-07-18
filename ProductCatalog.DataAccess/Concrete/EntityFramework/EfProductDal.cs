using Microsoft.EntityFrameworkCore;
using ProductCatalog.Core.DataAccess.EntityFramework;
using ProductCatalog.DataAccess.Abstract;
using ProductCatalog.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, ProductCatalogDbContext>, IProductDal
    {
        public EfProductDal(ProductCatalogDbContext context) : base(context)
        {
                
        }
    }
}
