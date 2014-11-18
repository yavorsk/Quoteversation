namespace Quoteversation.Web.InputModels.Quotes
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Quoteversation.Models;

    public class QuoteInputModel
    {
        [Required]
        [Display(Name = "Quote")]
        public string QuoteText { get; set; }

        [Required]
        [Display(Name = "Quote Author")]
        public string QuoteAuthor { get; set; }

        [Required]
        [Display(Name = "Tags")]
        public string Tags { get; set; }
    }
}