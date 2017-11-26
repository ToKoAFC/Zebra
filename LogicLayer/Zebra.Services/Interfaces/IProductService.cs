using System.Collections.Generic;
using Zebra.ViewModels.Common;
using Zebra.ViewModels.View.AdminProducts;

namespace Zebra.Services.Interfaces
{
    public interface IProductService
    {
        List<VMProductBaseInfo> GetProducts();
        VMAdminProductsCreate GetProductForEdition(int productId);
        void SaveProduct(VMAdminProductsCreate product, string userName);
        bool DeleteProduct(int productId);
    }
}
