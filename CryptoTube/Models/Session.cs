using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CryptoTube.Models {
	public class Session {
		[Key]
		[ForeignKey("User")]
		public string Email { get; set; }
		public User User { get; set; }
		public DateTime ExpiresAt { get; set; }

		public DateTime Created { get; set; }
		public DateTime Modified { get; set; }
	}
}