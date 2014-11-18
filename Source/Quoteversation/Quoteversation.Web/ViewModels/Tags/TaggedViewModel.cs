namespace Quoteversation.Web.ViewModels.Tags
{
    using Quoteversation.Models;
    using Quoteversation.Web.ViewModels.Images;
    using Quoteversation.Web.ViewModels.Quotes;
    using Quoteversation.Web.ViewModels.Videos;
    using System.Collections.Generic;

    public class TaggedViewModel
    {
        public Tag Tag { get; set; }

        public IEnumerable<QuoteDetailsViewModel> Quotes { get; set; }

        public IEnumerable<VideoDetailsViewModel> Videos { get; set; }

        public IEnumerable<ImageDetailsViewModel> Images { get; set; }
    }
}