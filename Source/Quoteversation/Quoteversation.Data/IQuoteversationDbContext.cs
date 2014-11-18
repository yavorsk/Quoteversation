namespace Quoteversation.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Quoteversation.Models;

    public interface IQuoteversationDbContext
    {
        IDbSet<Conversation> Conversations { get; set; }

        IDbSet<Post> Posts { get; set; }

        IDbSet<PostContentPic> PostContentPics { get; set; }

        IDbSet<PostContentVideo> PostContentVideos { get; set; }

        IDbSet<PostContentQuote> PostContentQuotes { get; set; }

        IDbSet<Tag> Tags { get; set; }

        IDbSet<Like> Likes { get; set; }

        DbContext DbContext { get; }

        int SaveChanges();

        void Dispose();

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        IDbSet<T> Set<T>() where T : class;
    }
}
