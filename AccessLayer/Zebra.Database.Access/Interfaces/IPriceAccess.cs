using System.Collections.Generic;
using Zebra.CoreModels;

namespace Zebra.Database.Access.Interfaces
{
    public interface IPriceAccess
    {
        void SaveCategoryDiscount(CoreCategoryDiscount discount);
        List<CoreDiscount> GetDiscounts();
        void ChangeDiscountActivity(int discountId, bool setAs);
        CoreDiscount GetDiscount(int discountId);
        void DeleteDiscount(int discountId);
        decimal? GetProductPrice(int productId);
    }
}
