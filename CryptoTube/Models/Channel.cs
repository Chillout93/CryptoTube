using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CryptoTube.Models {
	public class Channel {
		public Channel() {
			Videos = new List<Video>();
			Subscribers = new List<Subscription>();
		}

		[Key]
		public string Name { get; set; }

		public virtual User Owner { get; set; }
		public virtual IList<Video> Videos { get; set; }
		public virtual IList<Subscription> Subscribers { get; set; }

		public DateTime Created { get; set; }
		public DateTime Modified { get; set; }
	}
}