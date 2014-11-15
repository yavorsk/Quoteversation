using Quoteversation.Data.Common.Repositories;
using Quoteversation.Models;
using Quoteversation.Web.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using Quoteversation.Data;

namespace Quoteversation.Web.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IQuoteversationData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            var conversations = this.Data.Conversations.All().OrderByDescending(c => c.CreatedOn).Project().To<IndexConversationViewModel>();

            return View(conversations);
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}