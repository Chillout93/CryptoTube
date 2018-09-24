using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CryptoTube.Models {
	public class User : IdentityUser {
		public User() {
			Views = new List<View>();
			Channels = new List<Channel>();
			Comments = new List<Comment>();
			Subscriptions = new List<Subscription>();
		}

		public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager) {
			var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
			return userIdentity;
		}

		public virtual IList<View> Views { get; set; }
		public virtual IList<Channel> Channels { get; set; }
		public virtual IList<Comment> Comments { get; set; }
		public virtual IList<Subscription> Subscriptions { get; set; }
	}
}