using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Zebra.Database.Models
{
    [Table("AppUsers")]
    public class DbAppUser : IdentityUser
    {
        public DbAppUser()
        {
            Id = new Guid().ToString();
        }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(256)]
        public string SecondName { get; set; }
        
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<DbAppUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
