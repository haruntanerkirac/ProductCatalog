using ProductCatalog.Core.DataAccess;
using ProductCatalog.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        
    }
}
