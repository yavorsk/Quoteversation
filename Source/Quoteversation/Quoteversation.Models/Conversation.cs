namespace Quoteversation.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;

    using Quoteversation.Data.Common.Models;

    public class Conversation : AuditInfo, IDeletableEntity
    {
        public Conversation()
        {
            this.Posts = new HashSet<Post>();
            this.Tags = new HashSet<Tag>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public string CreatorId { get; set; }

        public virtual ApplicationUser Creator { get; set; }

        public bool AllowPicPosts { get; set; }

        public bool AllowVideoPosts { get; set; }

        public bool AllowQuotePosts { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        public System.DateTime? DeletedOn { get; set; }
    }
}
