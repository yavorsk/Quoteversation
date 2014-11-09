
namespace Quoteversation.Data.Common.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public abstract class PostContent : AuditInfo, IDeletableEntity
    {
        [Key]
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
