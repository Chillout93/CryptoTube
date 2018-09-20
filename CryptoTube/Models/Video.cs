﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Web.Hosting;

namespace CryptoTube.Models {
	public class Video {
		public int ID { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string FileName { get; set; }
		
		public Channel Channel { get; set; }
		public virtual IList<View> Views { get; set; }
		public virtual IList<Comment> Comments { get; set; }
		
		[NotMapped]
		public string RelativeFilePath { get { return $"/Content/Videos/{FileName}"; } }

		[NotMapped]
		public string AbsoluteFilePath { get { return $"{HostingEnvironment.MapPath("~/Content/Videos")}/{FileName}"; } }

		public DateTime Created { get; set; }
		public DateTime Modified { get; set; }
	}
}