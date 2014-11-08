namespace Quoteversation.Data.Common.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Post : AuditInfo, IDeletableEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        public bool IsDeleted { get; set; }

        public System.DateTime? DeletedOn { get; set; }
    }
}
