namespace Quoteversation.Web.Controllers
{
    using Quoteversation.Data;
    using Quoteversation.Web.InputModels.Quotes;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using Quoteversation.Models;
    using AutoMapper.QueryableExtensions;
    using Quoteversation.Web.ViewModels.Quotes;

    public class QuotesController : BaseController
    {
        public QuotesController(IQuoteversationData data)
            : base(data)
        {
        }

        public ActionResult Details(int id)
        {
            var quoteViewModel = this.Data.PostContentQuotes.All().Where(q => q.Id == id)
                .Project().To<QuoteDetailsViewModel>().FirstOrDefault();

            if (quoteViewModel == null)
            {
                return this.HttpNotFound("No such post");
            }

            return View(quoteViewModel);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Add()
        {
            var model = new QuoteInputModel();

            return View(model);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Add(QuoteInputModel inputModel)
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

                var quote = new PostContentQuote
                {
                    UploaderId = userId,
                    QuoteText = inputModel.QuoteText,
                    QuoteAuthor = inputModel.QuoteAuthor,
                    Tags = tags
                };

                this.Data.PostContentQuotes.Add(quote);
                this.Data.SaveChanges();

                return this.RedirectToAction("Details", new { id = quote.Id });
            }

            return this.View(inputModel);
        }
    }
}