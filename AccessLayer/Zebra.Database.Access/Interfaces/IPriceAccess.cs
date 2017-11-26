using Zebra.CoreModels;

namespace Zebra.Database.Access.Interfaces
{
    public interface IPriceAccess
    {
        void SaveCategoryDiscount(CoreCategoryDiscount discount);
    }
}
