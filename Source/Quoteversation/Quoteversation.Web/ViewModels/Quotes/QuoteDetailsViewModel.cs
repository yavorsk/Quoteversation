namespace Quoteversation.Web.ViewModels.Quotes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    using Quoteversation.Models;
    using Quoteversation.Web.Infrastructure.Mapping;

    public class QuoteDetailsViewModel : IMapFrom<PostContentQuote>
    {
        public int Id { get; set; }

        public string QuoteText { get; set; }

        public string QuoteAuthor { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public virtual User Uploader { get; set; }
    }
}