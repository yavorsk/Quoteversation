namespace Quoteversation.Models
{
    using System.ComponentModel.DataAnnotations;

    using Quoteversation.Data.Common.Models;
    using System.Collections.Generic;

    public class PicPost : Post
    {
        public PicPost()
        {
            this.Likes = new HashSet<Like>();
        }

        [Required]
        public byte[] Pic { get; set; }

        public virtual ICollection<Like> Likes { get; set; }
    }
}
