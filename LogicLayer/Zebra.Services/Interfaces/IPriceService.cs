using System.Collections.Generic;
using Zebra.ViewModels.AdminCategory.Common;
using Zebra.ViewModels.View.AdminPrice;

namespace Zebra.Services.Interfaces
{
    public interface IPriceService
    {
        void SaveCategoryDiscount(VMAdminPriceCreate discount, string userId);
        List<VMDiscount> GetDiscounts();
        void ChangeDiscountActivity(int discountId, bool setAs);
        VMAdminPriceCreate GetDiscount(int discountId);
        void DeleteDiscount(int discountId);
    }
}