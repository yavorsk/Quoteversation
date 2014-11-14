
namespace Quoteversation.Web.Controllers
{
    using Quoteversation.Data;
    using Quoteversation.Web.InputModels.Videos;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using Quoteversation.Models;
    using AutoMapper.QueryableExtensions;
    using Quoteversation.Web.ViewModels.Videos;
    using System.Text.RegularExpressions;

    public class VideosController : BaseController
    {
        public VideosController(IQuoteversationData data)
            : base(data)
        {
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            var videoViewModel = this.Data.PostContentVideos.All()
                .Where(v => v.Id == id)
                .Project().To<VideoDetailsViewModel>()
                .FirstOrDefault();

            if (videoViewModel == null)
            {
                return this.HttpNotFound("No such video.");
            }

            return View(videoViewModel);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Add()
        {
            var model = new VideoInputModel();

            return View(model);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Add(VideoInputModel inputModel)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.Identity.GetUserId();

                var inputTags = inputModel.Tags.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                List<Tag> tags = new List<Tag>();

                var tagsFromDb = this.Data.Tags.All();

                foreach (var inputTagName in inputTags)
                {
                    Tag currentTag = tagsFromDb.FirstOrDefault(t => t.Name == inputTagName);

                    if (currentTag == null)
                    {
                        currentTag = new Tag
                        {
                            Name = inputTagName
                        };
                    }

                    tags.Add(currentTag);
                }

                // use regex to extract the video id
                Regex youTubeVideoRegex = new Regex(@"youtu(?:\.be|be\.com)/(?:(.*)v(/|=)|(.*/)?)([a-zA-Z0-9-_]+)", RegexOptions.IgnoreCase);
                Match youtubeMatch = youTubeVideoRegex.Match(inputModel.VideoUrl);
                string id = string.Empty;
                if (youtubeMatch.Success)
                {
                    id = youtubeMatch.Groups[4].Value;
                }
                inputModel.VideoUrl = "//www.youtube.com/embed/" + id;


                var video = new PostContentVideo
                {
                    UploaderId = userId,
                    VideoUrl = inputModel.VideoUrl,
                    SongTitle = inputModel.SongTitle == null ? "unknown" : inputModel.SongTitle,
                    Artist = inputModel.Artist == null ? "unknown" : inputModel.Artist,
                    Tags = tags
                };

                this.Data.PostContentVideos.Add(video);
                this.Data.SaveChanges();

                return this.RedirectToAction("Details", new { id = video.Id });
            }

            return this.View(inputModel);
        }
    }
}