using Zebra.ViewModels.AdminCategory.Common;

namespace Zebra.Services.Interfaces
{
    public interface IShopService
    {
        VMShop GetShopInfo();
        void SaveShopInfo(VMShop model);
    }
}