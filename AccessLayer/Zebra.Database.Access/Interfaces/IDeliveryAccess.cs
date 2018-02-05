using System.Collections.Generic;
using Zebra.CoreModels;

namespace Zebra.Database.Access.Interfaces
{
    public interface IDeliveryAccess
    {
        List<CoreDelivery> GetDeliveries();
        CoreDelivery GetDelivery(int deliveryId);
        void DeleteDelivery(int deliveryId);
        void SaveDelivery(CoreDelivery delivery);
    }
}
