using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CryptoTube.Models {
	public class Channel {
		[Key]
		public string Name { get; set; }

		public User Owner { get; set; }
		public virtual IList<Video> Videos { get; set; }
		public virtual IList<Subscription> Subscribers { get; set; }

		public DateTime Created { get; set; }
		public DateTime Modified { get; set; }
	}
}