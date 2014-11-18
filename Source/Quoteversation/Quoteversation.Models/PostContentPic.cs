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
        public byte[] PictureContent { get; set; }

        [Required]
        public string FileExtension { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public string UploaderId { get; set; }

        public virtual User Uploader { get; set; }
    }
}
