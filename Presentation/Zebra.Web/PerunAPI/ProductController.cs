using System.Collections.Generic;
using System.Web.Http;
using Zebra.CoreModels;
using Zebra.Database.Access;

namespace Zebra.Web.PerunAPI
{
    public class ProductController : ApiController
    {
        public ProductAccess _productAccess { get; set; }

        public List<CoreProduct> GetProductList()
        {
            return _productAccess.GetProducts();
        }
    }
}