namespace Quoteversation.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using Quoteversation.Data;
    using Quoteversation.Web.ViewModels.Tags;
    using Quoteversation.Models;
    using AutoMapper.QueryableExtensions;
    using Quoteversation.Web.ViewModels.Videos;
    using Quoteversation.Web.ViewModels.Quotes;
    using Quoteversation.Web.ViewModels.Images;

    public class TagsController : BaseController
    {
        public TagsController(IQuoteversationData data)
            : base(data)
        {
        }

        [HttpGet]
        public ActionResult All(int? convId)
        {
            var model = new AllTagsViewModel();

            model.Tags = this.Data.Tags.All()
                .OrderByDescending(t => t.CreatedOn)
                .Project().To<TagViewModel>()
                .ToList();

            ViewBag.ConvId = convId;

            return View(model);
        }

        public ActionResult Search(string query)
        {
            var result = new AllTagsViewModel();

            if (query == string.Empty)
            {
                result.Tags = this.Data.Tags.All()
                .OrderByDescending(t => t.CreatedOn)
                .Project().To<TagViewModel>()
                .ToList();
            }
            else
            {
                result.Tags = this.Data.Tags
                  .All()
                  .Where(t => t.Name.ToLower().Contains(query.ToLower()))
                  .Project().To<TagViewModel>()
                  .ToList();
            }

            return this.PartialView("_TagsResult", result);
        }

        [HttpGet]
        [Authorize]
        public ActionResult ById(int id, int? convId)
        {
            ViewBag.convId = convId;

            var model = new TaggedViewModel();

            model.Tag = this.Data.Tags.GetById(id);

            var videosForTagId = this.Data.PostContentVideos.All()
                .Select(vt => new
                {
                    videoId = vt.Id,
                    tagIds = vt.Tags.Select(t => t.Id)
                })
                .Where(vt => vt.tagIds.Contains(id))
                .Select(vt => vt.videoId)
                .ToList();

            model.Videos = this.Data.PostContentVideos.All()
                .Where(v => videosForTagId.Contains(v.Id))
                .OrderByDescending(v => v.CreatedOn)
                .Project().To<VideoDetailsViewModel>()
                .ToList();

            var quotesForTagId = this.Data.PostContentQuotes.All()
                .Select(q => new
                {
                    quoteId = q.Id,
                    tagIds = q.Tags.Select(t => t.Id)
                })
                .Where(q => q.tagIds.Contains(id))
                .Select(q => q.quoteId)
                .ToList();

            model.Quotes = this.Data.PostContentQuotes.All()
                .Where(q => quotesForTagId.Contains(q.Id))
                .OrderByDescending(q => q.CreatedOn)
                .Project().To<QuoteDetailsViewModel>()
                .ToList();

            var imagesForTagId = this.Data.PostContentPics.All()
                .Select(i => new
                {
                    imageId = i.Id,
                    tagIds = i.Tags.Select(t => t.Id)
                })
                .Where(i => i.tagIds.Contains(id))
                .Select(i => i.imageId)
                .ToList();

            model.Images = this.Data.PostContentPics.All()
                .Where(i => imagesForTagId.Contains(i.Id))
                .OrderByDescending(i => i.CreatedOn)
                .Project().To<ImageDetailsViewModel>()
                .ToList();

            return View(model);
        }
    }
}