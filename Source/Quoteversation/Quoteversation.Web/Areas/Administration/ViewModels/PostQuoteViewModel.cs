namespace Quoteversation.Web.Areas.Administration.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    
    using Quoteversation.Models;
    using Quoteversation.Web.Infrastructure.Mapping;

    public class PostQuoteViewModel : IMapFrom<PostContentQuote>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string QuoteText { get; set; }

        public string QuoteAuthor { get; set; }

        public bool IsApproved { get; set; }

        public bool IsDeleted { get; set; }

        public string UploaderName { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<PostContentQuote, PostQuoteViewModel>()
                .ForMember(q => q.UploaderName, opt => opt.MapFrom(m => m.Uploader.UserName));
        }
    }
}