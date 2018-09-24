using CryptoTube.Models;
using System.Collections.Generic;
using System.Web;

namespace CryptoTube.Views.Videos {
	public class VideoCreateViewModel {
		public HttpPostedFileBase File { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public Channel Channel { get; set; }
	}
}