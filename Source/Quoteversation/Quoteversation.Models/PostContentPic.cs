namespace Quoteversation.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Quoteversation.Data.Common.Models;

    // Inheritance with EF Code First: Part 2 – Table per Type (TPT)
    // http://weblogs.asp.net/manavi/inheritance-mapping-strategies-with-entity-framework-code-first-ctp5-part-2-table-per-type-tpt

    public class PostContentPic : PostContent
    {
        public PostContentPic()
        {
            this.Tags = new HashSet<Tag>();
        }

        [Required]
        public byte[] Picture { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public string UploaderId { get; set; }

        public virtual User Uploader { get; set; }
    }
}
