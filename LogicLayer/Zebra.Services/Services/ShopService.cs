using Zebra.CoreModels;
using Zebra.Database.Access;
using Zebra.ViewModels.AdminCategory.Common;
using Zebra.ViewModels.Common;

namespace Zebra.Services
{
    public class ShopService
    {
        public ShopAccess _shopAccess { get; set; }

        public VMShop GetShopInfo()
        {
            var coreShop = _shopAccess.GetShopInfo();
            return new VMShop
            {
                Email = coreShop.Email,
                Name = coreShop.Name,
                NIP = coreShop.NIP,
                Phone = coreShop.Phone,
                Regon = coreShop.Regon,
                Localization = new VMGeoLocal
                {
                    Address = coreShop.Address,
                    City = coreShop.City,
                    Country = coreShop.Country,
                    Latitude = coreShop.Latitude,
                    Longitude = coreShop.Longitude,
                    Region = coreShop.Region
                }
            };
        }

        public void SaveShopInfo(VMShop model)
        {
            var coreShop = new CoreShop
            {
                Address = model.Localization.Address,
                City = model.Localization.City,
                Country = model.Localization.Country,
                Email = model.Email,
                Latitude = model.Email,
                Longitude = model.Localization.Longitude,
                Name = model.Name,
                NIP = model.NIP,
                Phone = model.Phone,
                Region = model.Localization.Region,
                Regon = model.Regon
            };
            _shopAccess.SaveShopInfo(coreShop);
        }
    }
}