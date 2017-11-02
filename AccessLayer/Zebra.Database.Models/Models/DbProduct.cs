using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zebra.Database.Models
{
    [Table("Products")]
    public class DbProduct
    {
        public DbProduct()
        {
            ProductPrices = new HashSet<DbProductPrice>();
            Categories = new HashSet<DbCategory>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProuductId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsDeleted { get; set; }

        public decimal BasePrice { get; set; }

        public int CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public virtual DbCompany Company { get; set; }

        public virtual ICollection<DbProductPrice> ProductPrices { get; set; }
        public virtual ICollection<DbCategory> Categories { get; set; }
    }
}
