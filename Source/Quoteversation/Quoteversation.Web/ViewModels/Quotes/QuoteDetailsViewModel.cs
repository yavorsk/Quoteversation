namespace Quoteversation.Web.ViewModels.Quotes
{
    using Quoteversation.Models;
    using Quoteversation.Web.Infrastructure.Mapping;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class QuoteDetailsViewModel : IMapFrom<PostContentQuote>
    {
        public string QuoteText { get; set; }

        public string QuoteAuthor { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public virtual User Uploader { get; set; }
    }
}