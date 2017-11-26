using Zebra.CoreModels;

namespace Zebra.Database.Access.Interfaces
{
    public interface IShopAccess
    {
        CoreShop GetShopInfo();
        void SaveShopInfo(CoreShop coreShop);
    }
}
