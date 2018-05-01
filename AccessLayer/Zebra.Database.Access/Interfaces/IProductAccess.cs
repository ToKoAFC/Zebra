using System.Collections.Generic;
using Zebra.CoreModels;

namespace Zebra.Database.Access.Interfaces
{
    public interface IProductAccess
    {
        List<CoreProduct> GetCoreProduct();
        CoreProduct GetProduct(int produtId);
        CoreProduct GetProductByBarcode(int barcode);
        List<CoreProduct> GetProducts();
        void SaveProduct(CoreProduct product, int? companyId);
        bool DeleteProduct(int productId);
    }
}
