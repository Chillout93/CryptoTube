using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CryptoTube.Models
{
    // You can add profile data for the user by adding more properties to your User class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class User : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

		public virtual IList<View> Views { get; set; }
		public virtual IList<Channel> Channels { get; set; }
		public virtual IList<Comment> Comments { get; set; }
		public virtual IList<Subscription> Subscriptions { get; set; }
	}

    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

		public DbSet<Channel> Channels { get; set; }
		public DbSet<Comment> Comments { get; set; }
		public DbSet<Subscription> Subscriptions { get; set; }
		public DbSet<Video> Videos { get; set; }
		public DbSet<View> Views { get; set; }
    }
}