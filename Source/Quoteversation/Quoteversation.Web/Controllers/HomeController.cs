namespace Quoteversation.Web.Controllers
{ 
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Quoteversation.Data;
    using Quoteversation.Data.Common.Repositories;
    using Quoteversation.Models;
    using Quoteversation.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
        public HomeController(IQuoteversationData data)
            : base(data)
        {
        }

        
        public ActionResult Index()
        {
            //var conversations = this.Data.Conversations.All().OrderByDescending(c => c.CreatedOn).Project().To<IndexConversationViewModel>();

            return View();
        }

        [OutputCache(Duration = 10 * 60)]
        [ChildActionOnly]
        public ActionResult CachedConversations()
        {
            var conversations = this.Data.Conversations.All().OrderByDescending(c => c.CreatedOn).Project().To<IndexConversationViewModel>();

            return this.PartialView(conversations);
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}