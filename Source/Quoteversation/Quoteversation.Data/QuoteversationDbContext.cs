﻿namespace Quoteversation.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Linq;

    using Microsoft.AspNet.Identity.EntityFramework;

    using Quoteversation.Data.Common.Models;
    using Quoteversation.Models;
    using Quoteversation.Data.Migrations;

    public class QuoteversationDbContext : IdentityDbContext<User>, IQuoteversationDbContext
    {
        public QuoteversationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<QuoteversationDbContext, Configuration>());
        }

        public IDbSet<Conversation> Conversations { get; set; }

        public IDbSet<Post> Posts { get; set; }

        public IDbSet<PostContentPic> PostContentPics { get; set; }

        public IDbSet<PostContentVideo> PostContentVideos { get; set; }

        public IDbSet<PostContentQuote> PostContentQuotes { get; set; }

        public IDbSet<Tag> Tags { get; set; }

        public IDbSet<Like> Likes { get; set; }

        public DbContext DbContext
        {
            get { return this; }
        }

        public static QuoteversationDbContext Create()
        {
            return new QuoteversationDbContext();
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    if (!entity.PreserveCreatedOn)
                    {
                        entity.CreatedOn = DateTime.Now;
                    }
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }

        private void ApplyDeletableEntityRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (
                var entry in
                    this.ChangeTracker.Entries()
                        .Where(e => e.Entity is IDeletableEntity && (e.State == EntityState.Deleted)))
            {
                var entity = (IDeletableEntity)entry.Entity;

                entity.DeletedOn = DateTime.Now;
                entity.IsDeleted = true;
                entry.State = EntityState.Modified;
            }
        }
    }
}
