using Quoteversation.Models;
using Quoteversation.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quoteversation.Web.ViewModels.Home
{
    public class IndexConversationViewModel : IMapFrom<Conversation>
    {
        public IndexConversationViewModel()
        {
            this.Posts = new HashSet<Post>();
            this.Tags = new HashSet<Tag>();
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public virtual User Creator { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}