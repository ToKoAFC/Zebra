using System;
using System.Collections.Generic;
using System.Linq;
using Zebra.CoreModels;
using Zebra.Database.Access.Interfaces;
using Zebra.Database.Models;

namespace Zebra.Database.Access
{
    public class DeliveryAccess : IDeliveryAccess
    {
        private readonly ZebraContext _context;
        public DeliveryAccess(ZebraContext context)
        {
            _context = context;
        }

        public void DeleteDelivery(int deliveryId)
        {
            var dbDelivery = _context.Deliveries.Where(p => p.DeliveryId == deliveryId).FirstOrDefault();
            if (dbDelivery == null)
            {
                return;
            }
            try
            {
                _context.Deliveries.Remove(dbDelivery);
                _context.SaveChanges();
                return;
            }
            catch (Exception)
            {
                return;
            }
        }

        public List<CoreDelivery> GetDeliveries()
        {
            var deliveries = (from d in _context.Deliveries
                              select new CoreDelivery
                              {
                                  Cost = d.Cost,
                                  DeliveryId = d.DeliveryId,
                                  DeliveryTimeMax = d.DeliveryTimeMax,
                                  DeliveryTimeMin = d.DeliveryTimeMin,
                                  Name = d.Name
                              }).ToList();
            return deliveries;
        }

        public CoreDelivery GetDelivery(int deliveryId)
        {
            var delivery = _context.Deliveries
                            .Where(p => p.DeliveryId == deliveryId)
                            .Select(del => new CoreDelivery
                            {
                                Name = del.Name,
                                Cost = del.Cost,
                                DeliveryId = del.DeliveryId,
                                DeliveryTimeMin = del.DeliveryTimeMin,
                                DeliveryTimeMax = del.DeliveryTimeMax
                            })
                            .FirstOrDefault();
            return delivery;
        }

        public void SaveDelivery(CoreDelivery delivery)
        {
            var dbDelivery = _context.Deliveries.Where(p => p.DeliveryId == delivery.DeliveryId).FirstOrDefault();
            if (dbDelivery != null)
            {
                dbDelivery.Name = delivery.Name;
                dbDelivery.Cost = delivery.Cost;
                dbDelivery.DeliveryTimeMax = delivery.DeliveryTimeMax;
                dbDelivery.DeliveryTimeMin = delivery.DeliveryTimeMin;
                _context.SaveChanges();
                return;
            }
            _context.Deliveries.Add(new DbDelivery
            {
                Name = delivery.Name,
                Cost = delivery.Cost,
                DeliveryTimeMax = delivery.DeliveryTimeMax,
                DeliveryTimeMin = delivery.DeliveryTimeMin
            });
            _context.SaveChanges();
        }
    }
}
