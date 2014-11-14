namespace Quoteversation.Web.InputModels.Videos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class VideoInputModel
    {
        [Required]
        [Display(Name = "Url")]
        public string VideoUrl { get; set; }

        [MaxLength(60)]
        [Display(Name = "Song Title")]
        public string SongTitle { get; set; }

        [MaxLength(60)]
        [Display(Name = "Artist")]
        public string Artist { get; set; }

        [Required]
        [Display(Name = "Tags")]
        public string Tags { get; set; }
    }
}