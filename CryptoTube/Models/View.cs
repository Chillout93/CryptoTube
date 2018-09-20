using System;

namespace CryptoTube.Models {
	public class View {
		public int ID { get; set; }
		public User User { get; set; }
		public Video Video { get; set; }

		public DateTime Created { get; set; }
		public DateTime Modified { get; set; }
	}
}