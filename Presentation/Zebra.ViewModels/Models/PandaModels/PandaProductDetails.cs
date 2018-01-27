using System.Collections.Generic;

namespace Zebra.ViewModels.Models.PandaModels
{
    public class PandaProductDetails
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Categories { get; set; }
        public decimal BasePrice { get; set; }
        public decimal? DiscountPrice { get; set; }
    }
}
