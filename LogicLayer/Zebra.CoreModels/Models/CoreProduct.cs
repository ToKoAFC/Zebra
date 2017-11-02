using System.Collections.Generic;

namespace Zebra.CoreModels
{
    public class CoreProduct
    {
        public int ProuductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal BasePrice { get; set; }

        public List<CoreCategory> Categories { get; set; }
    }
}
