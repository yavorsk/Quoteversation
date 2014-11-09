namespace Quoteversation.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Quoteversation.Data.Common.Models;

    public class Like
    {
        [Key]
        public int Id { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public int PostId { get; set; }

        public virtual Post Post { get; set; }
    }
}
