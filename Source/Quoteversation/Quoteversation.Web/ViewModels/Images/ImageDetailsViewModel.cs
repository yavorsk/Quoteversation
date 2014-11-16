namespace Quoteversation.Web.ViewModels.Images
{
    using Quoteversation.Models;
    using Quoteversation.Web.Infrastructure.Mapping;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class ImageDetailsViewModel : IMapFrom<PostContentPic>
    {
        public int Id { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public User Uploader { get; set; }
    }
}