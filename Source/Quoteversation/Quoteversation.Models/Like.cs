namespace Quoteversation.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Quoteversation.Data.Common.Models;

    public class Like
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey]
        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        [ForeignKey]
        public int PostId { get; set; }

        public virtual Post Post { get; set; }
    }
}
