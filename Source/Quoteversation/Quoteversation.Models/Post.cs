namespace Quoteversation.Models
{
    using Quoteversation.Data.Common.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Post : AuditInfo, IDeletableEntity
    {
        [Key]
        public int Id { get; set; }

        public Post()
        {
            this.Likes = new HashSet<Like>();
        }

        [ForeignKey("Author")]
        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        public bool IsDeleted { get; set; }

        public System.DateTime? DeletedOn { get; set; }

        public virtual ICollection<Like> Likes { get; set; }

        public int ConversationId { get; set; }

        public virtual Conversation Conversation { get; set; }

        [ForeignKey("Quote")]
        public int? QuoteId { get; set; }

        public PostContentQuote Quote { get; set; }

        [ForeignKey("Video")]
        public int? VideoId { get; set; }

        public PostContentVideo Video { get; set; }

        [ForeignKey("Pic")]
        public int? PicId { get; set; }

        public PostContentPic Pic { get; set; }
    }
}
