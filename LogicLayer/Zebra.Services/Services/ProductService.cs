using System.Collections.Generic;
using System.Linq;
using Zebra.CoreModels;
using Zebra.Database.Access.Interfaces;
using Zebra.Services.Interfaces;
using Zebra.ViewModels.AdminCategory.Common;
using Zebra.ViewModels.Common;
using Zebra.ViewModels.View.AdminProducts;

namespace Zebra.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductAccess _productAccess;
        private readonly IUserAccess _userAccess;
        public ProductService(IProductAccess productAccess, IUserAccess userAccess)
        {
            _productAccess = productAccess;
            _userAccess = userAccess;
        }

        public List<VMProductBaseInfo> GetProducts()
        {
            var coreProducts = _productAccess.GetCoreProduct();
            return coreProducts.Select(p => new VMProductBaseInfo
            {
                Description = p.Description,
                Name = p.Name,
                ProductId = p.ProuductId,
                Barcode = p.Barcode,
                FileName = p.FileName,
                HasImage = p.HasImage,
                BasePrice = p.BasePrice == 0 ? "---" : $"{p.BasePrice} zł",
                Categories = p.Categories.Select(cat => new VMCategory
                {
                    CategoryId = cat.CategoryId,
                    CategoryName = cat.CategoryName

                }).ToList()
            }).ToList();
        }

        public VMProductBaseInfo GetProduct(int productId)
        {
            var product = _productAccess.GetProduct(productId);
            return new VMProductBaseInfo
            {
                Description = product.Description,
                Name = product.Name,
                ProductId = product.ProuductId,
                Barcode = product.Barcode,
                FileName = product.FileName,
                HasImage = product.HasImage,
                BasePrice = product.BasePrice == 0 ? "---" : $"{product.BasePrice} zł",
                Categories = product.Categories.Select(cat => new VMCategory
                {
                    CategoryId = cat.CategoryId,
                    CategoryName = cat.CategoryName
                }).ToList()
            };
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
                Barcode = coreProd.Barcode,
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
                Barcode = product.Barcode,
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
