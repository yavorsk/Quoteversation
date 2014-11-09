namespace Quoteversation.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    using Quoteversation.Data.Common.Models;

    public class VideoPost : Post
    {
        public VideoPost()
        {
            this.Likes = new HashSet<Like>();
        }

        public int VideoId { get; set; }

        public PostContentVideo Video { get; set; }

        public virtual ICollection<Like> Likes { get; set; }
    }
}
