using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CryptoTube.Models {
	public class Comment {

		[Key]
		public int ID { get; set; }
		
		public virtual User User { get; set; }
		public virtual Video Video { get; set; }
		public string Description { get; set; }

		public DateTime Created { get; set; }
		public DateTime Modified { get; set; }
	}
}