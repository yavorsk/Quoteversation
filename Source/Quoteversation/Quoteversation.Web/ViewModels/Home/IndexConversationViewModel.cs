namespace Quoteversation.Web.ViewModels.Home
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    using Quoteversation.Models;
    using Quoteversation.Web.Infrastructure.Mapping;

    public class IndexConversationViewModel : IMapFrom<Conversation>
    {
        public IndexConversationViewModel()
        {
            this.Posts = new HashSet<Post>();
            this.Tags = new HashSet<Tag>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public virtual User Creator { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}