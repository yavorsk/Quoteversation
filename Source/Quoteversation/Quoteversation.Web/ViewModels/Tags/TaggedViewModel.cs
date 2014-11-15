namespace Quoteversation.Web.ViewModels.Tags
{
    using Quoteversation.Models;
    using Quoteversation.Web.ViewModels.Quotes;
    using Quoteversation.Web.ViewModels.Videos;
    using System.Collections.Generic;

    public class TaggedViewModel
    {
        public Tag Tag;

        public IEnumerable<QuoteDetailsViewModel> Quotes;

        public IEnumerable<VideoDetailsViewModel> Videos;
    }
}