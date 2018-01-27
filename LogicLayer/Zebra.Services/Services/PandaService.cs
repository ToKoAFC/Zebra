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
        public PandaService(IProductAccess productAccess, IPriceAccess priceAccess)
        {
            _productAccess = productAccess;
            _priceAccess = priceAccess;
        }

        public List<PandaProductDetails> GetProductDetails(List<int> ids)
        {
            var result = new List<PandaProductDetails>();
            ids.ForEach(prod =>
            {
                var product = _productAccess.GetProduct(prod);
                if (product != null)
                {
                    result.Add(new PandaProductDetails
                    {
                        BasePrice = product.BasePrice,
                        Categories = product.Categories.Select(x => x.CategoryName).ToList(),
                        Description = product.Description,
                        Name = product.Name,
                        ProductId = product.ProuductId,
                        DiscountPrice = _priceAccess.GetProductPrice(product.ProuductId)
                    });
                }
            });
            return result;
        }

        public List<int> GetProductsIds()
        {
            var coreProducts = _productAccess.GetCoreProduct();
            return coreProducts.Select(p => p.ProuductId).ToList();
        }
    }
}
