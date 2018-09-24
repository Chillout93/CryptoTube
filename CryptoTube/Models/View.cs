using System;

namespace CryptoTube.Models {
	public class View {

		public int ID { get; set; }
		public virtual User User { get; set; }
		public virtual Video Video { get; set; }

		public DateTime Created { get; set; }
		public DateTime Modified { get; set; }
	}
}