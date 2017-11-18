using System;
using System.IO;
using System.Linq;
using System.Web;
using Zebra.CoreModels;
using Zebra.Database.Models;
using Zebra.Global;

namespace Zebra.Database.Access
{
    public class ShopAccess
    {
        private readonly ZebraContext _context;
        public ShopAccess(ZebraContext context)
        {
            _context = context;
        }

        public CoreShop GetShopInfo()
        {
            var shop = _context.Shops.FirstOrDefault();
            if (shop == null)
            {
                return new CoreShop();
            }
            return new CoreShop
            {
                Address = shop.Address,
                City = shop.City,
                Country = shop.Country,
                Email = shop.Email,
                Latitude = shop.Latitude,
                Longitude = shop.Longitude,
                Name = shop.Name,
                NIP = shop.NIP,
                Phone = shop.Phone,
                Region = shop.Region,
                Regon = shop.Regon
            };
        }

        public void SaveShopInfo(CoreShop coreShop)
        {
            var dbShop = _context.Shops.FirstOrDefault();
            if (dbShop == null)
            {
                return;
            }
            dbShop.Address = coreShop.Address;
            dbShop.City = coreShop.City;
            dbShop.Country = coreShop.Country;
            dbShop.Email = coreShop.Email;
            dbShop.Latitude = coreShop.Latitude;
            dbShop.Longitude = coreShop.Longitude;
            dbShop.Name = coreShop.Name;
            dbShop.NIP = coreShop.NIP;
            dbShop.Phone = coreShop.Phone;
            dbShop.Region = coreShop.Region;
            dbShop.Regon = coreShop.Regon;
            _context.SaveChanges();
        }
    }
}
