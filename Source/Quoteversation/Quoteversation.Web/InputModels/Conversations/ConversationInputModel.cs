namespace Quoteversation.Web.InputModels.Conversations
{
    using System.ComponentModel.DataAnnotations;

    public class ConversationInputModel
    {
        [Required]
        [MaxLength(100)]
        [Display(Name = "Conversation Title")]
        public string Title { get; set; }

        [Required]
        [MaxLength(500)]
        [Display(Name = "Conversation Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Tags")]
        public string Tags { get; set; }
    }
}