namespace Quoteversation.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Quoteversation.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Quoteversation.Data.QuoteversationDbContext>
    {
        private UserManager<User> userManager;

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(QuoteversationDbContext context)
        {
            this.userManager = new UserManager<User>(new UserStore<User>(context));
            this.SeedRoles(context);
            this.SeedUsers(context);

            if (context.Conversations.Any())
            {
                return;
            }

            List<Conversation> conversations = new List<Conversation>();

            List<Post> posts = new List<Post>();

            List<PostContentQuote> quotes = new List<PostContentQuote>();

            List<Tag> tags = new List<Tag> 
            {
                new Tag() { Name = "Monday", CreatedOn=DateTime.Now, IsDeleted=false },
                new Tag() { Name = "Fun", CreatedOn=DateTime.Now, IsDeleted=false },
                new Tag() { Name = "Whatever", CreatedOn=DateTime.Now, IsDeleted=false },
                new Tag() { Name = "Quotes", CreatedOn=DateTime.Now, IsDeleted=false },
                new Tag() { Name = "Music", CreatedOn=DateTime.Now, IsDeleted=false },
                new Tag() { Name = "Metal", CreatedOn=DateTime.Now, IsDeleted=false },
                new Tag() { Name = "Hip-hop", CreatedOn=DateTime.Now, IsDeleted=false }
            };

            quotes.Add(new PostContentQuote
            {
                CreatedOn = DateTime.Now.AddDays(-5),
                IsDeleted = false,
                QuoteText = "And remember: there's nothing wrong about mondays. It's your life that sucks.",
                QuoteAuthor = "Ricky Gervais",
                Tags = new List<Tag> { tags[0], tags[2] }
            });
            quotes.Add(new PostContentQuote
            {
                CreatedOn = DateTime.Now.AddDays(-4),
                IsDeleted = false,
                QuoteText = "THERE'S NO JUSTICE. THERE'S ONLY ME.",
                QuoteAuthor = "Death, Terry Pratchett",
                Tags = new List<Tag> { tags[1], tags[3] }
            });
            quotes.Add(new PostContentQuote
            {
                CreatedOn = DateTime.Now.AddDays(-3),
                IsDeleted = false,
                QuoteText = "We lie best when we lie to ourselves.",
                QuoteAuthor = "Stephen King",
                Tags = new List<Tag> { tags[2], tags[4] }
            });
            quotes.Add(new PostContentQuote
            {
                CreatedOn = DateTime.Now.AddDays(-2),
                IsDeleted = false,
                QuoteText = "We all float down here.",
                QuoteAuthor = "Stephen King",
                Tags = new List<Tag> { tags[5], tags[6] }
            });

            posts.Add(new Post
            {
                CreatedOn = DateTime.Now.AddDays(-5),
                IsDeleted = false,
                Title = "Some title",
                Quote = quotes[1],
                Pic = null,
                Video = null
            });
            posts.Add(new Post
            {
                CreatedOn = DateTime.Now.AddDays(-4),
                IsDeleted = false,
                Title = "Other title",
                Quote = quotes[0],
                Pic = null,
                Video = null
            });
            posts.Add(new Post
            {
                CreatedOn = DateTime.Now.AddDays(-3),
                IsDeleted = false,
                Title = "Third title",
                Quote = quotes[2],
                Pic = null,
                Video = null
            });
            posts.Add(new Post
            {
                CreatedOn = DateTime.Now.AddDays(-2),
                IsDeleted = false,
                Title = "Fourth title",
                Quote = quotes[3],
                Pic = null,
                Video = null
            });

            conversations.Add(new Conversation
            {
                CreatedOn = DateTime.Now.AddDays(-6),
                IsDeleted = false,
                Title = "First Quote Conversaton",
                Posts = new List<Post> { posts[0], posts[1], posts[2] },
                Tags = new List<Tag> { tags[2], tags[4], tags[5] },
                Description = "bla bla, blablalbalba, bla bla blabla.",
                AllowPicPosts = false,
                AllowQuotePosts = true,
                AllowVideoPosts = false
            });
            conversations.Add(new Conversation
            {
                CreatedOn = DateTime.Now.AddDays(-5),
                IsDeleted = false,
                Title = "Second Quote Conversaton",
                Posts = new List<Post> { posts[2], posts[0], posts[3] },
                Tags = new List<Tag> { tags[2] },
                Description = "Here we will discuss out disgust of mondays.",
                AllowPicPosts = false,
                AllowQuotePosts = true,
                AllowVideoPosts = false
            });
            conversations.Add(new Conversation
            {
                CreatedOn = DateTime.Now.AddDays(-3),
                IsDeleted = false,
                Title = "Third Quote Conversaton",
                Posts = new List<Post> { posts[1], posts[2], posts[0] },
                Tags = new List<Tag> { tags[2], tags[5], tags[4], tags[1] },
                Description = "The force awakens is the title of the new Star Wars movie!",
                AllowPicPosts = false,
                AllowQuotePosts = true,
                AllowVideoPosts = false
            });

            context.Tags.AddOrUpdate(tags.ToArray());
            context.PostContentQuotes.AddOrUpdate(quotes.ToArray());
            context.Posts.AddOrUpdate(posts.ToArray());
            context.Conversations.AddOrUpdate(conversations.ToArray());
        }

        private void SeedRoles(QuoteversationDbContext context)
        {
            context.Roles.AddOrUpdate(x => x.Name, new IdentityRole("Admin"));
            context.SaveChanges();
        }

        private void SeedUsers(QuoteversationDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            var userPesho = new User
            {
                Email = "pesho@pesho.com",
                UserName = "peshopesho"
            };

            var userGosho = new User
            {
                Email = "gosho@gosho.com",
                UserName = "goshogosho"
            };

            var userYasho = new User
            {
                Email = "yasho@yasho.com",
                UserName = "yashoyasho"
            };

            var userAdmin = new User
            {
                Email = "admin@admin.com",
                UserName = "administrator"
            };

            this.userManager.Create(userPesho, "qweasd");
            this.userManager.Create(userGosho, "qweasd");
            this.userManager.Create(userYasho, "qweasd");
            this.userManager.Create(userAdmin, "qweasd");

            this.userManager.AddToRole(userAdmin.Id, "Admin");
        }
    }
}
