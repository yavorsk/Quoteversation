namespace Quoteversation.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Quoteversation.Data.Common.Models;

    public class PostContentQuote : PostContent
    {
        public PostContentQuote()
        {
            this.Tags = new HashSet<Tag>();
        }

        [Required]
        public string QuoteText { get; set; }

        [Required]
        public string QuoteAuthor { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public string UploaderId { get; set; }

        public virtual User Uploader { get; set; }
    }
}

