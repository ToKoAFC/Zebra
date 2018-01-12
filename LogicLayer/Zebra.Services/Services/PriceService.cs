using System.Collections.Generic;
using System.Linq;
using Zebra.CoreModels;
using Zebra.Database.Access.Interfaces;
using Zebra.Services.Interfaces;
using Zebra.ViewModels.AdminCategory.Common;
using Zebra.ViewModels.View.AdminPrice;

namespace Zebra.Services
{
    public class PriceService : IPriceService
    {
        private readonly IPriceAccess _priceAccess;
        public PriceService(IPriceAccess priceAccess)
        {
            _priceAccess = priceAccess;
        }

        public void SaveCategoryDiscount(VMAdminPriceCreate discount, string userId)
        {
            var coreDiscount = new CoreCategoryDiscount
            {
                CategoryId = discount.CategoryId,
                DiscountPercent = discount.DiscountPercent,
                IsActive = discount.IsActive,
                Description = discount.Description,
                DiscountId = discount.DiscountId,
                IsDeleted = discount.IsDeleted,
                Name = discount.Name
            };
            _priceAccess.SaveCategoryDiscount(coreDiscount);
        }

        public List<VMDiscount> GetDiscounts()
        {
            var coreDiscounts = _priceAccess.GetDiscounts();
            return coreDiscounts.Select(x => new VMDiscount
            {
                Name = x.Name,
                IsActive = x.IsActive,
                DiscountId = x.DiscountId,
                Description = x.Description,
                DiscountPercent = x.DiscountPercent,
                Categories = string.Join(", ", x.Categories.Select(c => c.CategoryName).ToList())
            }).ToList();
        }

        public void ChangeDiscountActivity(int discountId, bool setAs)
        {
            _priceAccess.ChangeDiscountActivity(discountId, setAs);
        }

        public VMAdminPriceCreate GetDiscount(int discountId)
        {
            var coreDiscount = _priceAccess.GetDiscount(discountId);
            return new VMAdminPriceCreate
            {
                IsActive = coreDiscount.IsActive,
                Description = coreDiscount.Description,
                DiscountId = coreDiscount.DiscountId,
                DiscountPercent = coreDiscount.DiscountPercent,
                Name = coreDiscount.Name
            };
        }

        public void DeleteDiscount(int discountId)
        {
             _priceAccess.DeleteDiscount(discountId);
        }
    }
}