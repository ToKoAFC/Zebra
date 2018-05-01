using System.Collections.Generic;
using System.Linq;
using Zebra.Database.Access.Interfaces;
using Zebra.Services.Interfaces;
using Zebra.ViewModels.Models.PandaModels;

namespace Zebra.Services
{
    public class PandaService : IPandaService
    {
        private readonly IProductAccess _productAccess;
        private readonly IPriceAccess _priceAccess;
        private readonly IShopAccess _shopAccess;
        public PandaService(IProductAccess productAccess, IPriceAccess priceAccess, IShopAccess shopAccess)
        {
            _productAccess = productAccess;
            _priceAccess = priceAccess;
            _shopAccess = shopAccess;
        }

        public List<PandaProductDetails> GetProductDetails(List<int> ids)
        {
            var result = new List<PandaProductDetails>();
            ids.ForEach(prod =>
            {
                var product = _productAccess.GetProductByBarcode(prod);
                if (product != null)
                {
                    result.Add(new PandaProductDetails
                    {
                        BasePrice = product.BasePrice,
                        Categories = product.Categories == null ? new List<string>() : product.Categories.Select(x => x.CategoryName).ToList(),
                        Description = product.Description,
                        Name = product.Name,
                        ProductId = product.ProuductId,
                        Barcode = product.Barcode,
                        DiscountPrice = _priceAccess.GetProductPrice(product.ProuductId)
                    });
                }
            });
            return result;
        }

        public List<int> GetProductsBarCodes()
        {
            var coreProducts = _productAccess.GetCoreProduct();
            return coreProducts.Select(p => p.Barcode).ToList();
        }

        public PandaShopInfo GetShopInfo()
        {   //validation
            var info = _shopAccess.GetShopInfo();
            return new PandaShopInfo
            {
                Address = info.Address,
                City = info.City,
                Country = info.Country,
                Email = info.Email,
                Latitude = info.Latitude,
                Longitude = info.Longitude,
                Name = info.Name,
                NIP = info.NIP,
                Phone = info.Phone,
                Region = info.Region,
                Regon = info.Regon
            };
        }
    }
}
