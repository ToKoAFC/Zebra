using System;
using System.Collections.Generic;
using System.Linq;
using Zebra.CoreModels;
using Zebra.Database.Access.Interfaces;
using Zebra.Database.Models;

namespace Zebra.Database.Access
{
    public class PriceAccess : IPriceAccess
    {
        private readonly ZebraContext _context;
        public PriceAccess(ZebraContext context)
        {
            _context = context;
        }

        public void ChangeDiscountActivity(int discountId, bool setAs)
        {
            var discount = (from d in _context.Discounts
                            where d.DiscountId == discountId
                            select d).FirstOrDefault();
            if (discount != null)
            {
                discount.IsActive = setAs;
                _context.SaveChanges();
            }
            return;
        }

        public void DeleteDiscount(int discountId)
        {
            var discount = (from d in _context.Discounts
                            where d.DiscountId == discountId
                            select d).FirstOrDefault();
            if (discount != null)
            {
                discount.IsDeleted = true;
                _context.SaveChanges();
            }
            return;
        }

        public CoreDiscount GetDiscount(int discountId)
        {
            var discount = (from d in _context.Discounts
                            where d.DiscountId == discountId
                            select new CoreDiscount
                            {
                                IsActive = d.IsActive,
                                Description = d.Description,
                                DiscountId = d.DiscountId,
                                DiscountPercent = d.DiscountPercent,
                                Name = d.Name,
                                Categories = d.Categories.Select(c => new CoreCategory
                                {
                                    CategoryId = c.CategoryId,
                                    CategoryName = c.Name
                                }).ToList()
                            }).FirstOrDefault();
            return discount;
        }

        public List<CoreDiscount> GetDiscounts()
        {
            var result = (from d in _context.Discounts
                          where !d.IsDeleted
                          select new CoreDiscount
                          {
                              Name = d.Name,
                              IsActive = d.IsActive,
                              Description = d.Description,
                              DiscountId = d.DiscountId,
                              DiscountPercent = d.DiscountPercent,
                              Categories = d.Categories.Select(c => new CoreCategory
                              {
                                  CategoryId = c.CategoryId,
                                  CategoryName = c.Name
                              }).ToList()
                          }).ToList();
            return result;
        }

        public void SaveCategoryDiscount(CoreCategoryDiscount discount)
        {
            var dbDiscount = (from d in _context.Discounts
                              where d.DiscountId == discount.DiscountId
                              select d).FirstOrDefault();
            if (dbDiscount == null)
            {
                dbDiscount = new DbDiscount
                {
                    IsActive = discount.IsActive,
                    IsDeleted = discount.IsDeleted,
                    Description = discount.Description,
                    DiscountPercent = discount.DiscountPercent,
                    Name = discount.Name
                };
                _context.Discounts.Add(dbDiscount);
            }
            else
            {
                dbDiscount.IsDeleted = discount.IsDeleted;
                dbDiscount.IsActive = discount.IsActive;
                dbDiscount.Name = discount.Name;
                dbDiscount.Description = discount.Description;
                dbDiscount.DiscountPercent = discount.DiscountPercent;
            }
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
