using System.ComponentModel;

namespace Zebra.ViewModels.AdminCategory.Common
{
    public class VMDelivery
    {
        public int DeliveryId { get; set; }
        [DisplayName("Nazwa")]
        public string Name { get; set; }
        [DisplayName("Koszt")]
        public decimal Cost { get; set; }
        [DisplayName("Minimalny czas dostawy")]
        public int DeliveryTimeMin { get; set; }
        [DisplayName("Maksymalny czas dostawy")]
        public int DeliveryTimeMax { get; set; }
    }
}
