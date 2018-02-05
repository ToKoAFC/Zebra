using System.Collections.Generic;
using System.Linq;
using Zebra.CoreModels;
using Zebra.Database.Access.Interfaces;
using Zebra.Services.Interfaces;
using Zebra.ViewModels.AdminCategory.Common;

namespace Zebra.Services
{
    public class DeliveryService : IDeliveryService
    {
        private readonly IDeliveryAccess _deliveryAccess;
        public DeliveryService(IDeliveryAccess deliveryAccess)
        {
            _deliveryAccess = deliveryAccess;
        }

        public void DeleteDelivery(int deliveryId)
        {
            _deliveryAccess.DeleteDelivery(deliveryId);
        }

        public List<VMDelivery> GetDeliveries()
        {
            var coreDeliveries = _deliveryAccess.GetDeliveries();
            return coreDeliveries.Select(c => new VMDelivery
            {
                Cost = c.Cost,
                DeliveryId = c.DeliveryId,
                DeliveryTimeMax = c.DeliveryTimeMax,
                DeliveryTimeMin = c.DeliveryTimeMin,
                Name = c.Name
            }).ToList();
        }

        public VMDelivery GetDelivery(int deliveryId)
        {
            var delivery = _deliveryAccess.GetDelivery(deliveryId);
            if (delivery == null)
            {
                return null;
            }
            return new VMDelivery
            {
                Cost = delivery.Cost,
                DeliveryId = delivery.DeliveryId,
                DeliveryTimeMax = delivery.DeliveryTimeMax,
                DeliveryTimeMin = delivery.DeliveryTimeMin,
                Name = delivery.Name
            };
        }

        public void SaveDelivery(VMDelivery delivery)
        {
            var coreDelivery = new CoreDelivery
            {
                Cost = delivery.Cost,
                DeliveryId = delivery.DeliveryId,
                DeliveryTimeMax = delivery.DeliveryTimeMax,
                DeliveryTimeMin = delivery.DeliveryTimeMin,
                Name = delivery.Name
            };
            _deliveryAccess.SaveDelivery(coreDelivery);
        }
    }
}