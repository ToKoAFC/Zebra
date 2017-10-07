using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zebra.Database.Models
{
    [Table("Companies")]
    public class DbCompany
    {
        public DbCompany()
        {
            Users = new HashSet<DbAppUser>();
            Products = new HashSet<DbProduct>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompanyId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [Required]
        [StringLength(50)]
        public string Adress { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.PostalCode)]
        public string PostalCode { get; set; }

        public string Description { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<DbAppUser> Users { get; set; }
        public virtual ICollection<DbProduct> Products { get; set; }
    }
}
