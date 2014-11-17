namespace Quoteversation.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using Quoteversation.Data;
    using Quoteversation.Web.Controllers;

    //[Authorize(Roles = "Admin")]
    public abstract class AdminController : BaseController
    {
        public AdminController(IQuoteversationData data)
            : base(data)
        {

        }
    }
}