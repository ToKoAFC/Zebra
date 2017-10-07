using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using Zebra.Database.Models;

namespace Zebra.Database
{
    public class ZebraContext : IdentityDbContext<DbAppUser>
    {
        public DbSet<DbCompany> Companies { get; set; }
        public DbSet<DbProduct> Products { get; set; }
        public DbSet<DbProductPrice> ProductPrices { get; set; }

        public ZebraContext()
            : base("ZebraContext", throwIfV1Schema: false)
        {
        }
        protected override void OnModelCreating(DbModelBuilder builder)
        {
            System.Data.Entity.Database.SetInitializer<ZebraContext>(null);
            base.OnModelCreating(builder);
        }

        public static ZebraContext Create()
        {
            return new ZebraContext();
        }
        
    }
}
