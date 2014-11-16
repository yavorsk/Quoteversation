namespace Quoteversation.Web.ViewModels.Quotes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class AllQuotesViewModel
    {
        public ICollection<QuoteDetailsViewModel> Quotes { get; set; }
    }
}