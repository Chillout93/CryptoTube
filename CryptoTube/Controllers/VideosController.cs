using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CryptoTube.Models;
using CryptoTube.Views.Videos;

namespace CryptoTube.Controllers
{
    public class VideosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Videos
        public ActionResult Index()
        {
            return View(db.Videos.ToList());
        }

        // GET: Videos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video video = db.Videos.Find(id);
            if (video == null)
            {
                return HttpNotFound();
            }
			if (!string.IsNullOrEmpty(HttpContext.User.Identity.Name)) {
				var user = db.Users.FirstOrDefault(x => x.Email == HttpContext.User.Identity.Name);

				var view = user.Views.FirstOrDefault(x => x.Video?.ID == video.ID) ?? new View() { Created = DateTime.UtcNow, User = user, Video = video };
				
				view.Modified = DateTime.UtcNow;
				video.Views.Add(view);
				db.SaveChanges();
			}

			video.RecommendedVideos = video.Views.Select(x => x.User).Select(x => x.Views.Where(y => y.Video?.ID != video.ID).Select(y => y.Video)).SelectMany(x => x).ToList();
			return View(video);
        }

        public ActionResult Create(string channelName)
        {
			var viewModel = new VideoCreateViewModel() { Channel = db.Channels.Find(channelName) };
			return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VideoCreateViewModel videoView)
        {
			var supportedFileTypes = new[] { ".mp4", ".webm", ".ogg" };
			if (!supportedFileTypes.Contains(Path.GetExtension(videoView.File.FileName)))
				ModelState.AddModelError("InvalidFileType", "The file type is not one of the supported: mp4, webm, ogg.");

			if (ModelState.IsValid) {
				var video = new Video() {
					FileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(videoView.File.FileName)}",
					Created = DateTime.UtcNow,
					Modified = DateTime.UtcNow,
					Title = videoView.Title,
					Description = videoView.Description
				};
				video.Channel = db.Channels.Find(videoView.Channel.Name);

				videoView.File.SaveAs(video.AbsoluteFilePath);

                db.Videos.Add(video);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(videoView);
        }

        // GET: Videos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video video = db.Videos.Find(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            return View(video);
        }

        // POST: Videos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Description,FileName,Created,Modified")] Video video)
        {
            if (ModelState.IsValid)
            {
                db.Entry(video).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(video);
        }

        // GET: Videos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video video = db.Videos.Find(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            return View(video);
        }

        // POST: Videos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Video video = db.Videos.Find(id);
            db.Videos.Remove(video);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
