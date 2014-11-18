namespace Quoteversation.Web.ViewModels.Conversations
{
    using Quoteversation.Models;
    using Quoteversation.Web.Infrastructure.Mapping;
    using Quoteversation.Web.ViewModels.Posts;
    using Quoteversation.Web.ViewModels.Tags;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class ConversationViewModel : IMapFrom<Conversation>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string CreatorId { get; set; }

        public string CreatorName { get; set; }

        public bool AllowPicPosts { get; set; }

        public bool AllowVideoPosts { get; set; }

        public bool AllowQuotePosts { get; set; }

        public ICollection<PostViewModel> Posts { get; set; }

        public ICollection<TagViewModel> Tags { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Conversation, ConversationViewModel>()
                .ForMember(c => c.CreatorName, opt => opt.MapFrom(m => m.Creator.UserName));
        }
    }
}