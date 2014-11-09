namespace Quoteversation.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Quoteversation.Data.Common.Models;

    public class PostContentPic : PostContent
    {
        public PostContentPic()
        {
            this.Tags = new HashSet<Tag>();
        }

        [Required]
        public byte[] Picture { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}
