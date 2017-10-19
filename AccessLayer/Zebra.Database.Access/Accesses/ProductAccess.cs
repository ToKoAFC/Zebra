using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zebra.CoreModels;

namespace Zebra.Database.Access
{
    public class ProductAccess
    {
        private readonly ZebraContext _context;
        public ProductAccess(ZebraContext context)
        {
            _context = context;
        }

        public List<CoreProduct> GetCoreProduct()
        {
            return _context.Products
                .Select(prod => new CoreProduct(prod.ProuductId, prod.Name, prod.Description))
                .ToList();
        }
    }
}
