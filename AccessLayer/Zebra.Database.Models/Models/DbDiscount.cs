using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zebra.Database.Models
{
    [Table("Discounts")]
    public class DbDiscount
    {
        public DbDiscount()
        {
            Categories = new HashSet<DbCategory>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DiscountId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsDeleted { get; set; }

        public int DiscountPercent { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<DbCategory> Categories { get; set; }
    }
}
