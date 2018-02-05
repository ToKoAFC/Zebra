using System.Collections.Generic;

namespace Zebra.CoreModels
{
    public class CoreDelivery
    {
        public int DeliveryId { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public int DeliveryTimeMin { get; set; }
        public int DeliveryTimeMax { get; set; }
    }
}
