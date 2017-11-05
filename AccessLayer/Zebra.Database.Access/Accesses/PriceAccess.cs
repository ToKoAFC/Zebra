using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zebra.CoreModels;
using Zebra.Database.Models;

namespace Zebra.Database.Access
{
    public class PriceAccess
    {
        private readonly ZebraContext _context;
        public PriceAccess(ZebraContext context)
        {
            _context = context;
        }

        //public List<CoreProduct> GetCoreProduct()
        //{
        //    return _context.Products
        //        .Select(prod => new CoreProduct
        //        {
        //            Name = prod.Name,
        //            Description = prod.Description,
        //            ProuductId = prod.ProuductId,
        //            BasePrice = prod.BasePrice,
        //            Categories = prod.Categories.Select(cat => new CoreCategory
        //            {
        //                CategoryId = cat.CategoryId,
        //                CategoryName = cat.Name
        //            }).ToList()
        //        })
        //        .ToList();
        //}

        //public CoreProduct GetProduct(int produtId)
        //{
        //    var product = _context.Products
        //        .Where(p => p.ProuductId == produtId)
        //        .Select(prod => new CoreProduct
        //        {
        //            Name = prod.Name,
        //            Description = prod.Description,
        //            ProuductId = prod.ProuductId,
        //            BasePrice = prod.BasePrice
        //        })
        //        .FirstOrDefault();
        //    return product;
        //}

        public void SaveCategoryDiscount(CoreCategoryDiscount discount)
        {
            var dbProducts = _context.Products
                .Where(p => p.Categories.Any(cat => cat.CategoryId == discount.CategoryId))
                .ToList();
            if (!dbProducts.Any())
            {
                return;
            }
            dbProducts.ForEach(prod =>
            prod.ProductPrices.Add(new DbProductPrice
            {
                CreatedDate = DateTime.Now,
                Value = prod.BasePrice * discount.DiscountPercent
            }));
            _context.SaveChanges();
        }

        //public bool DeleteProduct(int productId)
        //{
        //    var dbProduct = _context.Products.Where(p => p.ProuductId == productId).FirstOrDefault();
        //    if (dbProduct == null)
        //    {
        //        return false;
        //    }
        //    try
        //    {
        //        _context.Products.Remove(dbProduct);
        //        _context.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }

        //}
    }
}
