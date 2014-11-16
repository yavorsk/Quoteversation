namespace Quoteversation.Web.InputModels.Images
{
    using Quoteversation.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class ImageInputModel
    {
        [Required]
        [Display(Name = "Tags")]
        public string Tags { get; set; }

        public HttpPostedFileBase UploadedImage { get; set; }
    }
}