namespace Zebra.CoreModels
{
    public class CoreProduct
    {
        public CoreProduct(int productId, string name, string description)
        {
            this.ProuductId = productId;
            this.Name = name;
            this.Description = description;
        }
        public int ProuductId { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }
    }
}
