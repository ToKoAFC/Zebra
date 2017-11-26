using Zebra.Database.Access.Interfaces;
using Zebra.Services.Interfaces;

namespace Zebra.Services
{
    public class PriceService : IPriceService
    {
        private readonly IPriceAccess _priceAccess;
        public PriceService(IPriceAccess priceAccess)
        {
            _priceAccess = priceAccess;
        }
     
        public void CreateCategory(string categoryName, int? parentId)
        {
          //  _priceAccess.AddNewCategory(categoryName, parentId);
        }
    }
}