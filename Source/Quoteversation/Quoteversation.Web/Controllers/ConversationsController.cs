namespace Quoteversation.Web.Controllers
{
    using Quoteversation.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using Microsoft.AspNet.Identity;
    using Quoteversation.Web.ViewModels.Conversations;
    using Quoteversation.Web.ViewModels.Posts;
    using Quoteversation.Web.ViewModels.Images;
    using Quoteversation.Web.ViewModels.Videos;
    using Quoteversation.Web.ViewModels.Quotes;
    using Quoteversation.Models;

    public class ConversationsController : BaseController
    {
        public ConversationsController(IQuoteversationData data)
            : base(data)
        {
        }

        [HttpGet]
        [Authorize]
        public ActionResult ById(int id)
        {
            var userId = this.User.Identity.GetUserId();

            var conversationModel = this.Data.Conversations.All()
                .Where(c => c.Id == id)
                .Project().To<ConversationViewModel>()
                .FirstOrDefault();

            var postsForConversation = this.Data.Posts.All()
                .Where(p => p.ConversationId == id)
                .OrderByDescending(p => p.CreatedOn)
                .Project().To<PostViewModel>()
                .ToList();


            foreach (var post in postsForConversation)
            {
                post.Liked = this.Data.Likes.All()
                    .Where(l => l.PostId == post.Id && l.AuthorId == userId)
                    .Any();

                if (post.PicId != null)
                {
                    post.Image = this.Data.PostContentPics.All()
                        .Where(p => p.Id == post.PicId)
                        .Project().To<ImageDetailsViewModel>()
                        .FirstOrDefault();

                    continue;
                }

                if (post.VideoId != null)
                {
                    post.Video = this.Data.PostContentVideos.All()
                        .Where(v => v.Id == post.VideoId)
                        .Project().To<VideoDetailsViewModel>()
                        .FirstOrDefault();

                    continue;
                }

                if (post.QuoteId != null)
                {
                    post.Quote = this.Data.PostContentQuotes.All()
                        .Where(q => q.Id == post.QuoteId)
                        .Project().To<QuoteDetailsViewModel>()
                        .FirstOrDefault();

                    continue;
                }
            }

            conversationModel.Posts = postsForConversation;

            return View(conversationModel);
        }

        public ActionResult Like(int postId)
        {
            var userId = this.User.Identity.GetUserId();

            var likesForPost = this.Data.Likes.All()
                .Where(l => l.PostId == postId).ToList();

            if (likesForPost.FirstOrDefault(l => l.AuthorId == userId) == null)
            {
                var newLike = new Like
                {
                    AuthorId = userId,
                    PostId = postId
                };

                this.Data.Likes.Add(newLike);
                this.Data.SaveChanges();
            }

            var postModel = this.Data.Posts.All()
                .Where(p => p.Id == postId)
                .Project().To<PostViewModel>()
                .FirstOrDefault();

            postModel.Liked = true;

            return this.PartialView("_LikesCount", postModel);
        }
    }
}