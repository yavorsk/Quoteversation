using Quoteversation.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quoteversation.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        public BaseController(IQuoteversationData data)
        {
            this.Data = data;
        }

        protected IQuoteversationData Data { get; set; }

        protected ApplicationUserManager CurrentUser { get; set; }
    }
}