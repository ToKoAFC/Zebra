using System.Collections.Generic;
using Zebra.ViewModels.Models.PandaModels;

namespace Zebra.Services.Interfaces
{
    public interface IPandaService
    {
        List<int> GetProductsIds();
        List<PandaProductDetails> GetProductDetails(List<int> ids);
        PandaShopInfo GetShopInfo();
    }
}
