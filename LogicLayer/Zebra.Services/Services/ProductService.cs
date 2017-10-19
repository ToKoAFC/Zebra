using System.Collections.Generic;
using System.Linq;
using Zebra.Database.Access;
using Zebra.ViewModels;

namespace Zebra.Services
{
    public class ProductService
    {
        private ProductAccess _productAccess { get; set; }

        public List<VMProduct> GetProducts()
        {
            var coreProducts = _productAccess.GetCoreProduct();
            return coreProducts.Select(p => new VMProduct
            {
                Description = p.Description,
                Name = p.Name,
                ProductId = p.ProuductId
            }).ToList();
        }
    }
}
