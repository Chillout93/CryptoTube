using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CryptoTube.Models {
	public class Subscription {
		[ForeignKey("User")]
		[Key, Column(Order = 0)]
		public string UserEmail { get; set; }

		[ForeignKey("Channel")]
		[Key, Column(Order = 1)]
		public string Name { get; set; }
		
		public User User { get; set; }
		public Channel Channel { get; set; }

		public DateTime Created { get; set; }
		public DateTime Modified { get; set; }
	}
}