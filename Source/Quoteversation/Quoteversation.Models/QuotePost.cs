namespace Quoteversation.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    using Quoteversation.Data.Common.Models;

    public class QuotePost : Post
    {
        public QuotePost()
        {
            this.Likes = new HashSet<Like>();
        }

        public int QuoteId { get; set; }

        public PostContentQuote Quote { get; set; }

        public virtual ICollection<Like> Likes { get; set; }
    }
}
