﻿namespace Quoteversation.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Quoteversation.Data.Common.Repositories;
    using Quoteversation.Models;

    public interface IQuoteversationData
    {
        IQuoteversationDbContext Context { get; }

        IDeletableEntityRepository<Conversation> Conversations { get; }

        IDeletableEntityRepository<Post> Posts { get; }

        IDeletableEntityRepository<PostContentPic> PostContentPics { get; }

        IDeletableEntityRepository<PostContentVideo> PostContentVideos { get; }

        IDeletableEntityRepository<PostContentQuote> PostContentQuotes { get; }

        IDeletableEntityRepository<Tag> Tags { get; }

        IRepository<Like> Likes { get; }

        int SaveChanges();
    }
}
