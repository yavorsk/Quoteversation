namespace Quoteversation.Web.ViewModels.Videos
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Quoteversation.Models;
    using Quoteversation.Web.Infrastructure.Mapping;

    public class VideoDetailsViewModel : IMapFrom<PostContentVideo>
    {
        public int Id { get; set; }

        public string VideoUrl { get; set; }

        public string SongTitle { get; set; }

        public string Artist { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public virtual User Uploader { get; set; }
    }
}