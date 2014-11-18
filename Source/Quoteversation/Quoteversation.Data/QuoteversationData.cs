namespace Quoteversation.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Quoteversation.Data.Common.Models;
    using Quoteversation.Data.Common.Repositories;
    using Quoteversation.Models;

    public class QuoteversationData : IQuoteversationData
    {
        private readonly IQuoteversationDbContext context;

        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public QuoteversationData(IQuoteversationDbContext context)
        {
            this.context = context;
        }

        public IQuoteversationDbContext Context
        {
            get { return this.context; }
        }

        public IDeletableEntityRepository<Conversation> Conversations
        {
            get { return this.GetDeletableEntityRepository<Conversation>(); }
        }

        public IDeletableEntityRepository<Post> Posts
        {
            get { return this.GetDeletableEntityRepository<Post>(); }
        }

        public IDeletableEntityRepository<PostContentPic> PostContentPics
        {
            get { return this.GetDeletableEntityRepository<PostContentPic>(); }
        }

        public IDeletableEntityRepository<PostContentVideo> PostContentVideos
        {
            get { return this.GetDeletableEntityRepository<PostContentVideo>(); }
        }

        public IDeletableEntityRepository<PostContentQuote> PostContentQuotes
        {
            get { return this.GetDeletableEntityRepository<PostContentQuote>(); }
        }

        public IDeletableEntityRepository<Tag> Tags
        {
            get { return this.GetDeletableEntityRepository<Tag>(); }
        }

        public IRepository<Like> Likes
        {
            get { return this.GetRepository<Like>(); }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }

        private IDeletableEntityRepository<T> GetDeletableEntityRepository<T>() where T : class, IDeletableEntity
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(DeletableEntityRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IDeletableEntityRepository<T>)this.repositories[typeof(T)];
        }
    }
}
