namespace Quoteversation.Web.ViewModels.Posts
{
    using Quoteversation.Models;
    using Quoteversation.Web.Infrastructure.Mapping;
    using Quoteversation.Web.ViewModels.Images;
    using Quoteversation.Web.ViewModels.Quotes;
    using Quoteversation.Web.ViewModels.Videos;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class PostViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string AuthorName { get; set; }

        public string Title { get; set; }

        //public virtual ICollection<Like> Likes { get; set; }

        public int LikesCount { get; set; }

        public int ConversationId { get; set; }

        public int? QuoteId { get; set; }

        //public PostContentQuote Quote { get; set; }

        public QuoteDetailsViewModel Quote { get; set; }

        public int? VideoId { get; set; }

        //public PostContentVideo Video { get; set; }

        public VideoDetailsViewModel Video { get; set; }

        public int? PicId { get; set; }

        //public PostContentPic Pic { get; set; }

        public ImageDetailsViewModel Image { get; set; }

        public bool Liked { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Post, PostViewModel>()
                .ForMember(p => p.AuthorName, opt => opt.MapFrom(m => m.Author.UserName))
                .ForMember(p => p.LikesCount, opt => opt.MapFrom(m => m.Likes.Count));
        }
    }
}