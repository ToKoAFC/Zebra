using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zebra.Database.Models
{
    [Table("ShopInfo")]
    public class DbShop
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ShopId { get; set; }

        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string NIP { get; set; }
        public string Regon { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
