namespace Quoteversation.Web.InputModels.Post
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class PostInputModel
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        public int ConversationId { get; set; }

        public int? QuoteId { get; set; }

        public int? VideoId { get; set; }

        public int? PicId { get; set; }
    }
}