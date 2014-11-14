namespace Quoteversation.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Quoteversation.Data.Common.Models;

    public class PostContentVideo : PostContent
    {
        public PostContentVideo()
        {
            this.Tags = new HashSet<Tag>();
        }

        [Required]
        public string VideoUrl { get; set; }

        [MaxLength(60)]
        public string SongTitle { get; set; }

        [MaxLength(60)]
        public string Artist { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public string UploaderId { get; set; }

        public virtual User Uploader { get; set; }
    }
}
