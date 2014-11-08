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

        [Required]
        public string VideoUrl { get; set; }

        [MaxLength(60)]
        public string SongTitle { get; set; }

        [MaxLength(60)]
        public string Artist { get; set; }

        public virtual ICollection<Like> Likes { get; set; }
    }
}
