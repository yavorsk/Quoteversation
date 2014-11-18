namespace Quoteversation.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;

    using Quoteversation.Data.Common.Models;

    public class Tag : AuditInfo, IDeletableEntity
    {
        public Tag()
        {
            this.Conversations = new HashSet<Conversation>();
            this.PostContentPics = new HashSet<PostContentPic>();
            this.PostContentQuotes = new HashSet<PostContentQuote>();
            this.PostContentVideos = new HashSet<PostContentVideo>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<PostContentPic> PostContentPics { get; set; }

        public virtual ICollection<PostContentVideo> PostContentVideos { get; set; }

        public virtual ICollection<PostContentQuote> PostContentQuotes { get; set; }

        public virtual ICollection<Conversation> Conversations { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        public System.DateTime? DeletedOn { get; set; }
    }
}
