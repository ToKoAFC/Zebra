using System.Collections.Generic;
using System.Linq;
using Zebra.CoreModels;
using Zebra.Database.Access;
using Zebra.ViewModels.AdminCategory.Common;
using Zebra.ViewModels.Common;
using Zebra.ViewModels.View.AdminProducts;

namespace Zebra.Services
{
    public class ProductService
    {
        public ProductAccess _productAccess { get; set; }
        public UserAccess _userAccess { get; set; }

        public List<VMProductBaseInfo> GetProducts()
        {
            var coreProducts = _productAccess.GetCoreProduct();
            return coreProducts.Select(p => new VMProductBaseInfo
            {
                Description = p.Description,
                Name = p.Name,
                ProductId = p.ProuductId,
                BasePrice = p.BasePrice == 0 ? "---" : $"{p.BasePrice} zł",
                Categories = p.Categories.Select(cat => new VMCategory
                {
                    CategoryId = cat.CategoryId,
                    CategoryName = cat.CategoryName
                }).ToList()
            }).ToList();
        }

        public VMAdminProductsCreate GetProductForEdition(int productId)
        {
            var coreProd = _productAccess.GetProduct(productId);
            if (coreProd == null)
            {
                return null;
            }
            return new VMAdminProductsCreate
            {
                ProductId = coreProd.ProuductId,
                Name = coreProd.Name,                
                BasePrice = coreProd.BasePrice,
                Description = coreProd.Description
            };
        }

        public void SaveProduct(VMAdminProductsCreate product, string userName)
        {
            var user = _userAccess.GetUser(userName);
            var coreProduct = new CoreProduct
            {
                ProuductId = product.ProductId,
                Name = product.Name,
                Description = product.Description,
                BasePrice = product.BasePrice
            };
            _productAccess.SaveProduct(coreProduct, user.CompanyId);
        }

        public bool DeleteProduct(int productId)
        {
            return _productAccess.DeleteProduct(productId);
        }
    }
}
