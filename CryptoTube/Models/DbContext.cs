using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CryptoTube.Models {
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