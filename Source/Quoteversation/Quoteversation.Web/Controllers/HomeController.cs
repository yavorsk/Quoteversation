using Quoteversation.Data.Common.Repositories;
using Quoteversation.Models;
using Quoteversation.Web.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;

namespace Quoteversation.Web.Controllers
{
    public class HomeController : Controller
    {
        private IRepository<Conversation> conversations;

        public HomeController(IRepository<Conversation> conversations)
        {
            this.conversations = conversations;

        }
        public ActionResult Index()
        {
            var conversations = this.conversations.All().OrderByDescending(c => c.CreatedOn).Project().To<IndexConversationViewModel>();

            return View(conversations);
        }
    }
}