using System.Collections.Generic;
using Zebra.ViewModels.AdminCategory.Common;

namespace Zebra.Services.Interfaces
{
    public interface IDeliveryService
    {
        List<VMDelivery> GetDeliveries();
        VMDelivery GetDelivery(int deliveryId);
        void SaveDelivery(VMDelivery delivery);
        void DeleteDelivery(int deliveryId);
    }
}
