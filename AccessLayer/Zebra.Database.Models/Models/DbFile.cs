using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Zebra.Global;

namespace Zebra.Database.Models
{
    [Table("Files")]
    public class DbFile
    {
        public DbFile()
        {
            Products = new HashSet<DbProduct>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(2048)]
        public string Name { get; set; }

        public MimeEnum Mime { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        public long Size { get; set; }

        public string FileName { get; set; }        

        public virtual ICollection<DbProduct> Products { get; set; }
    }
}
