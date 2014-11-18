namespace Quoteversation.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Reflection;
    using System.IO;
    using Quoteversation.Common;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Quoteversation.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Quoteversation.Data.QuoteversationDbContext>
    {
        private UserManager<User> userManager;
        private IRandomGenerator random;

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.random = new RandomGenerator();
        }

        protected override void Seed(QuoteversationDbContext context)
        {
            this.userManager = new UserManager<User>(new UserStore<User>(context));

            this.SeedRoles(context);
            this.SeedUsers(context);

            this.SeedTags(context);

            this.SeedQuotes(context);
            this.SeedPics(context);
            this.SeedVideos(context);

            this.SeedConversations(context);
            this.SeedPosts(context);
        }

        private void SeedPosts(QuoteversationDbContext context)
        {
            if (context.Posts.Any())
            {
                return;
            }

            var users = context.Users.ToList();
            var tags = context.Tags.ToList();
            var conversations = context.Conversations.ToList();
            var pics = context.PostContentPics.ToList();
            var videos = context.PostContentVideos.ToList();
            var quotes = context.PostContentQuotes.ToList();

            var posts = new List<Post>();

            posts.Add(new Post
            {
                Title = this.random.RandomString(6, 25),
                Author = users[this.random.RandomNumber(0, users.Count - 2)],
                Conversation = conversations[this.random.RandomNumber(0, conversations.Count - 2)],
                Quote = quotes[this.random.RandomNumber(0, quotes.Count - 2)],
                Pic = null,
                Video = null
            });
            posts.Add(new Post
            {
                Title = this.random.RandomString(6, 25),
                Author = users[this.random.RandomNumber(0, users.Count - 2)],
                Conversation = conversations[this.random.RandomNumber(0, conversations.Count - 2)],
                Quote = quotes[this.random.RandomNumber(0, quotes.Count - 2)],
                Pic = null,
                Video = null
            });
            posts.Add(new Post
            {
                Title = this.random.RandomString(6, 25),
                Author = users[this.random.RandomNumber(0, users.Count - 2)],
                Conversation = conversations[this.random.RandomNumber(0, conversations.Count - 2)],
                Quote = quotes[this.random.RandomNumber(0, quotes.Count - 2)],
                Pic = null,
                Video = null
            });
            posts.Add(new Post
            {
                Title = this.random.RandomString(6, 25),
                Author = users[this.random.RandomNumber(0, users.Count - 2)],
                Conversation = conversations[this.random.RandomNumber(0, conversations.Count - 2)],
                Quote = quotes[this.random.RandomNumber(0, quotes.Count - 2)],
                Pic = null,
                Video = null
            });
            posts.Add(new Post
            {
                Title = this.random.RandomString(6, 25),
                Author = users[this.random.RandomNumber(0, users.Count - 2)],
                Conversation = conversations[this.random.RandomNumber(0, conversations.Count - 2)],
                Quote = quotes[this.random.RandomNumber(0, quotes.Count - 2)],
                Pic = null,
                Video = null
            });
            posts.Add(new Post
            {
                Title = this.random.RandomString(6, 25),
                Author = users[this.random.RandomNumber(0, users.Count - 2)],
                Conversation = conversations[this.random.RandomNumber(0, conversations.Count - 2)],
                Quote = null,
                Pic = pics[this.random.RandomNumber(0, pics.Count - 2)],
                Video = null
            });
            posts.Add(new Post
            {
                Title = this.random.RandomString(6, 25),
                Author = users[this.random.RandomNumber(0, users.Count - 2)],
                Conversation = conversations[this.random.RandomNumber(0, conversations.Count - 2)],
                Quote = null,
                Pic = pics[this.random.RandomNumber(0, pics.Count - 2)],
                Video = null
            });
            posts.Add(new Post
            {
                Title = this.random.RandomString(6, 25),
                Author = users[this.random.RandomNumber(0, users.Count - 2)],
                Conversation = conversations[this.random.RandomNumber(0, conversations.Count - 2)],
                Quote = null,
                Pic = pics[this.random.RandomNumber(0, pics.Count - 2)],
                Video = null
            });
            posts.Add(new Post
            {
                Title = this.random.RandomString(6, 25),
                Author = users[this.random.RandomNumber(0, users.Count - 2)],
                Conversation = conversations[this.random.RandomNumber(0, conversations.Count - 2)],
                Quote = null,
                Pic = pics[this.random.RandomNumber(0, pics.Count - 2)],
                Video = null
            });
            posts.Add(new Post
            {
                Title = this.random.RandomString(6, 25),
                Author = users[this.random.RandomNumber(0, users.Count - 2)],
                Conversation = conversations[this.random.RandomNumber(0, conversations.Count - 2)],
                Quote = null,
                Pic = null,
                Video = videos[this.random.RandomNumber(0, videos.Count - 2)]
            });
            posts.Add(new Post
            {
                Title = this.random.RandomString(6, 25),
                Author = users[this.random.RandomNumber(0, users.Count - 2)],
                Conversation = conversations[this.random.RandomNumber(0, conversations.Count - 2)],
                Quote = null,
                Pic = null,
                Video = videos[this.random.RandomNumber(0, videos.Count - 2)]
            });
            posts.Add(new Post
            {
                Title = this.random.RandomString(6, 25),
                Author = users[this.random.RandomNumber(0, users.Count - 2)],
                Conversation = conversations[this.random.RandomNumber(0, conversations.Count - 2)],
                Quote = null,
                Pic = null,
                Video = videos[this.random.RandomNumber(0, videos.Count - 2)]
            });
            posts.Add(new Post
            {
                Title = this.random.RandomString(6, 25),
                Author = users[this.random.RandomNumber(0, users.Count - 2)],
                Conversation = conversations[this.random.RandomNumber(0, conversations.Count - 2)],
                Quote = null,
                Pic = null,
                Video = videos[this.random.RandomNumber(0, videos.Count - 2)]
            });
            posts.Add(new Post
            {
                Title = this.random.RandomString(6, 25),
                Author = users[this.random.RandomNumber(0, users.Count - 2)],
                Conversation = conversations[this.random.RandomNumber(0, conversations.Count - 2)],
                Quote = null,
                Pic = null,
                Video = videos[this.random.RandomNumber(0, videos.Count - 2)]
            });
            posts.Add(new Post
            {
                Title = this.random.RandomString(6, 25),
                Author = users[this.random.RandomNumber(0, users.Count - 2)],
                Conversation = conversations[this.random.RandomNumber(0, conversations.Count - 2)],
                Quote = null,
                Pic = null,
                Video = videos[this.random.RandomNumber(0, videos.Count - 2)]
            });

            context.Posts.AddOrUpdate(posts.ToArray());
        }

        private void SeedConversations(QuoteversationDbContext context)
        {
            if (context.Conversations.Any())
            {
                return;
            }

            var users = context.Users.ToList();
            var tags = context.Tags.ToList();

            var conversations = new List<Conversation>();

            conversations.Add(new Conversation
            {
                Title = "First Random Conversaton",
                Tags = new List<Tag> { tags[this.random.RandomNumber(0, tags.Count - 2)], tags[this.random.RandomNumber(0, tags.Count - 2)], tags[this.random.RandomNumber(0, tags.Count - 2)] },
                Description = this.random.RandomString(6, 30),
                AllowPicPosts = true,
                AllowQuotePosts = true,
                AllowVideoPosts = true,
                Creator = users[0]
            });

            conversations.Add(new Conversation
            {
                Title = "Second Random Conversaton",
                Tags = new List<Tag> { tags[this.random.RandomNumber(0, tags.Count - 2)], tags[this.random.RandomNumber(0, tags.Count - 2)], tags[this.random.RandomNumber(0, tags.Count - 2)] },
                Description = this.random.RandomString(6, 30),
                AllowPicPosts = true,
                AllowQuotePosts = true,
                AllowVideoPosts = true,
                Creator = users[1]
            });

            conversations.Add(new Conversation
            {
                Title = "Third Random Conversaton",
                Tags = new List<Tag> { tags[this.random.RandomNumber(0, tags.Count - 2)], tags[this.random.RandomNumber(0, tags.Count - 2)], tags[this.random.RandomNumber(0, tags.Count - 2)] },
                Description = this.random.RandomString(6, 30),
                AllowPicPosts = true,
                AllowQuotePosts = true,
                AllowVideoPosts = true,
                Creator = users[2]
            });

            conversations.Add(new Conversation
            {
                Title = "Fourth Random Conversaton",
                Tags = new List<Tag> { tags[this.random.RandomNumber(0, tags.Count - 2)], tags[this.random.RandomNumber(0, tags.Count - 2)], tags[this.random.RandomNumber(0, tags.Count - 2)] },
                Description = this.random.RandomString(6, 30),
                AllowPicPosts = true,
                AllowQuotePosts = true,
                AllowVideoPosts = true,
                Creator = users[3]
            });

            context.Conversations.AddOrUpdate(conversations.ToArray());
            context.SaveChanges();
        }

        private void SeedVideos(QuoteversationDbContext context)
        {
            if (context.PostContentVideos.Any())
            {
                return;
            }

            List<PostContentVideo> videos = new List<PostContentVideo>();

            var users = context.Users.ToList();
            var tags = context.Tags;

            videos.Add(new PostContentVideo
            {
                 Artist = "REM",
                 SongTitle = "Everybody Hurts",
                 Tags = new List<Tag> { tags.Where(t => t.Name == "Love").FirstOrDefault() },
                 Uploader = users[0],
                 VideoUrl = YouTubeUrlHelpers.GetEmbedUrl("https://www.youtube.com/watch?v=ijZRCIrTgQc")
            });
            videos.Add(new PostContentVideo
            {
                Artist = "Laurent Wolf",
                SongTitle = "No Stress",
                Tags = new List<Tag> { tags.Where(t => t.Name == "Work").FirstOrDefault() },
                Uploader = users[1],
                VideoUrl = YouTubeUrlHelpers.GetEmbedUrl("https://www.youtube.com/watch?v=bVRnMrl2oj8")
            });
            videos.Add(new PostContentVideo
            {
                Artist = "Dire Straits",
                SongTitle = "Money for nothing",
                Tags = new List<Tag> { tags.Where(t => t.Name == "Work").FirstOrDefault() },
                Uploader = users[2],
                VideoUrl = YouTubeUrlHelpers.GetEmbedUrl("https://www.youtube.com/watch?v=wTP2RUD_cL0")
            });
            videos.Add(new PostContentVideo
            {
                Artist = "Slipknot",
                SongTitle = "People = shit",
                Tags = new List<Tag> { tags.Where(t => t.Name == "Metal").FirstOrDefault() },
                Uploader = users[2],
                VideoUrl = YouTubeUrlHelpers.GetEmbedUrl("https://www.youtube.com/watch?v=u6ZtHrWiSAk")
            });

            context.PostContentVideos.AddOrUpdate(videos.ToArray());
        }

        private void SeedPics(QuoteversationDbContext context)
        {
            if (context.PostContentPics.Any())
            {
                return;
            }

            List<PostContentPic> pics = new List<PostContentPic>();

            var users = context.Users.ToList();
            var tags = context.Tags;

            pics.Add(new PostContentPic
            {
                 Uploader = users[0],
                 PictureContent = this.GetSampleImage("foundlove.jpg"),
                 Tags = new List<Tag> { tags.Where(t => t.Name == "Love").FirstOrDefault() },
                 FileExtension = "jpg"
            });

            pics.Add(new PostContentPic
            {
                Uploader = users[1],
                PictureContent = this.GetSampleImage("gollum.jpg"),
                Tags = new List<Tag> { tags.Where(t => t.Name == "Love").FirstOrDefault() },
                FileExtension = "jpg"
            });

            pics.Add(new PostContentPic
            {
                Uploader = users[2],
                PictureContent = this.GetSampleImage("hardwork.jpg"),
                Tags = new List<Tag> { tags.Where(t => t.Name == "Work").FirstOrDefault(), tags.Where(t => t.Name == "Job").FirstOrDefault(), },
                FileExtension = "jpg"
            });

            pics.Add(new PostContentPic
            {
                Uploader = users[2],
                PictureContent = this.GetSampleImage("hatework.jpg"),
                Tags = new List<Tag> { tags.Where(t => t.Name == "Work").FirstOrDefault(), tags.Where(t => t.Name == "Job").FirstOrDefault(), },
                FileExtension = "jpg"
            });

            pics.Add(new PostContentPic
            {
                Uploader = users[3],
                PictureContent = this.GetSampleImage("takeoffearly.jpg"),
                Tags = new List<Tag> { tags.Where(t => t.Name == "Work").FirstOrDefault(), tags.Where(t => t.Name == "Job").FirstOrDefault(), },
                FileExtension = "jpg"
            });

            pics.Add(new PostContentPic
            {
                Uploader = users[0],
                PictureContent = this.GetSampleImage("whatislove.jpg"),
                Tags = new List<Tag> { tags.Where(t => t.Name == "Love").FirstOrDefault() },
                FileExtension = "jpg"
            });

            context.PostContentPics.AddOrUpdate(pics.ToArray());
        }

        private void SeedQuotes(QuoteversationDbContext context)
        {
            if (context.PostContentQuotes.Any())
            {
                return;
            }

            List<PostContentQuote> quotes = new List<PostContentQuote>();

            var users = context.Users.ToList();
            var tags = context.Tags.OrderBy(t => t.Name);

            quotes.Add(new PostContentQuote
            {
                QuoteText = "And remember: there's nothing wrong about mondays. It's your life that sucks.",
                QuoteAuthor = "Ricky Gervais",
                Uploader = users[0],
                Tags = new List<Tag> { tags.Where(t => t.Name == "Monday").FirstOrDefault() }
            });
            quotes.Add(new PostContentQuote
            {
                QuoteText = "We lie best when we lie to ourselves.",
                QuoteAuthor = "Stephen King",
                Uploader = users[2],
                Tags = new List<Tag> { tags.Where(t => t.Name == "Monday").FirstOrDefault() }
            });
            quotes.Add(new PostContentQuote
            {
                QuoteText = "There is always some madness in love. But there is also always some reason in madness.",
                QuoteAuthor = "Friedrich Nietzsche",
                Uploader = users[2],
                Tags = new List<Tag> { tags.Where(t => t.Name == "Love").FirstOrDefault() }
            });
            quotes.Add(new PostContentQuote
            {
                QuoteText = "When love is not madness it is not love.",
                QuoteAuthor = "Pedro Calderón de la Barca",
                Uploader = users[0],
                Tags = new List<Tag> { tags.Where(t => t.Name == "Love").FirstOrDefault() }
            });
            quotes.Add(new PostContentQuote
            {
                QuoteText = "Find what you love and let it kill you.",
                QuoteAuthor = "Charles Bukowski",
                Uploader = users[0],
                Tags = new List<Tag> { tags.Where(t => t.Name == "Love").FirstOrDefault() }
            });
            quotes.Add(new PostContentQuote
            {
                QuoteText = "Oh yes, the past can hurt. But you can either run from it, or learn from it.",
                QuoteAuthor = "Rafiki, from The Lion King",
                Uploader = users[1],
                Tags = new List<Tag> { }
            });
            quotes.Add(new PostContentQuote
            {
                QuoteText = "Every story has an end, but in life every ending is just a new begining.",
                QuoteAuthor = "Uptown Girls",
                Uploader = users[2],
                Tags = new List<Tag> { }
            });
            quotes.Add(new PostContentQuote
            {
                QuoteText = "Everybody's afraid of something.That's how we know we care about things.... when we're scared to lose them.",
                QuoteAuthor = "from \"The Shawshank Redemption\"",
                Uploader = users[3],
                Tags = new List<Tag> { }
            });
            quotes.Add(new PostContentQuote
            {
                QuoteText = "The truth is, everyone is going to hurt you. You just got to find the ones worth suffering for.",
                QuoteAuthor = "Bob Marley",
                Uploader = users[0],
                Tags = new List<Tag> { }
            });
            quotes.Add(new PostContentQuote
            {
                QuoteText = "That which does not kill us makes us stronger.",
                QuoteAuthor = "Friedrich Nietzsche",
                Uploader = users[1],
                Tags = new List<Tag> { }
            });
            quotes.Add(new PostContentQuote
            {
                QuoteText = "I don't know the question, but sex is definitely the answer.",
                QuoteAuthor = "Woody Allen",
                Uploader = users[2],
                Tags = new List<Tag> { }
            });

            quotes.Add(new PostContentQuote
            {
                QuoteText = "Choose a job you love, and you will never have to work a day in your life.",
                QuoteAuthor = "Confucius",
                Uploader = users[1],
                Tags = new List<Tag> { tags.Where(t => t.Name == "Work").FirstOrDefault(), tags.Where(t => t.Name == "Job").FirstOrDefault() }
            });
            quotes.Add(new PostContentQuote
            {
                QuoteText = "I like work: it fascinates me. I can sit and look at it for hours.",
                QuoteAuthor = "Jerome K. Jerome",
                Uploader = users[2],
                Tags = new List<Tag> { tags.Where(t => t.Name == "Work").FirstOrDefault(), tags.Where(t => t.Name == "Job").FirstOrDefault() }
            });
            quotes.Add(new PostContentQuote
            {
                QuoteText = "Either write something worth reading or do something worth writing.",
                QuoteAuthor = "Benjamin Franklin",
                Uploader = users[3],
                Tags = new List<Tag> { tags.Where(t => t.Name == "Work").FirstOrDefault(), tags.Where(t => t.Name == "Job").FirstOrDefault() }
            });
            quotes.Add(new PostContentQuote
            {
                QuoteText = "I don't know the key to success, but the key to failure is trying to please everyone.",
                QuoteAuthor = "Bill Cosby",
                Uploader = users[0],
                Tags = new List<Tag> { tags.Where(t => t.Name == "Work").FirstOrDefault(), tags.Where(t => t.Name == "Job").FirstOrDefault() }
            });
            quotes.Add(new PostContentQuote
            {
                QuoteText = "Be yourself; everyone else is already taken.",
                QuoteAuthor = "Oscar Wilde",
                Uploader = users[2],
                Tags = new List<Tag> { tags.Where(t => t.Name == "Work").FirstOrDefault(), tags.Where(t => t.Name == "Job").FirstOrDefault() }
            });
            quotes.Add(new PostContentQuote
            {
                QuoteText = "Always forgive your enemies; nothing annoys them so much.",
                QuoteAuthor = "Oscar Wilde",
                Uploader = users[1],
                Tags = new List<Tag> { tags.Where(t => t.Name == "Work").FirstOrDefault(), tags.Where(t => t.Name == "Job").FirstOrDefault() }
            });

            quotes.Add(new PostContentQuote
            {
                QuoteText = "’Life is what happens to you while you’re busy making other plans.",
                QuoteAuthor = "Allen Saunders",
                Uploader = users[2],
                Tags = new List<Tag> { tags.Where(t => t.Name == "Life").FirstOrDefault() }
            });
            quotes.Add(new PostContentQuote
            {
                QuoteText = "Yesterday is history, tomorrow is a mystery, today is a gift of God, which is why we call it the present.",
                QuoteAuthor = "Bil Keane",
                Uploader = users[3],
                Tags = new List<Tag> { tags.Where(t => t.Name == "Life").FirstOrDefault() }
            });
            quotes.Add(new PostContentQuote
            {
                QuoteText = "Life is like riding a bicycle. To keep your balance, you must keep moving.",
                QuoteAuthor = "Albert Einstein",
                Uploader = users[0],
                Tags = new List<Tag> { tags.Where(t => t.Name == "Life").FirstOrDefault() }
            });
            quotes.Add(new PostContentQuote
            {
                QuoteText = "Everybody is a genius. But if you judge a fish by its ability to climb a tree, it will live its whole life believing that it is stupid.",
                QuoteAuthor = "Albert Einstein",
                Uploader = users[1],
                Tags = new List<Tag> { tags.Where(t => t.Name == "Life").FirstOrDefault() }
            });
            quotes.Add(new PostContentQuote
            {
                QuoteText = "Knowing yourself is the beginning of all wisdom.",
                QuoteAuthor = "Aristotle",
                Uploader = users[2],
                Tags = new List<Tag> { tags.Where(t => t.Name == "Life").FirstOrDefault() }
            });
            quotes.Add(new PostContentQuote
            {
                QuoteText = "If you don't know where you're going, any road'll take you there",
                QuoteAuthor = "George Harrison",
                Uploader = users[3],
                Tags = new List<Tag> { tags.Where(t => t.Name == "Life").FirstOrDefault() }
            });
            quotes.Add(new PostContentQuote
            {
                QuoteText = "Some humans would do anything to see if it was possible to do it. If you put a large switch in some cave somewhere, with a sign on it saying 'End-of-the-World Switch. PLEASE DO NOT TOUCH', the paint wouldn't even have time to dry.",
                QuoteAuthor = "Terry Pratchett",
                Uploader = users[1],
                Tags = new List<Tag> { tags.Where(t => t.Name == "Life").FirstOrDefault() }
            });
            quotes.Add(new PostContentQuote
            {
                QuoteText = "When his life was ruined, his family killed, his farm destroyed, Job knelt down on the ground and yelled up to the heavens, Why god? Why me? and the thundering voice of God answered, Theres just something about you that pisses me off.",
                QuoteAuthor = "Stephen King",
                Uploader = users[2],
                Tags = new List<Tag> { tags.Where(t => t.Name == "Life").FirstOrDefault() }
            });
            quotes.Add(new PostContentQuote
            {
                QuoteText = "Everyone thinks of changing the world, but no one thinks of changing himself.",
                QuoteAuthor = "Leo Tolstoy",
                Uploader = users[1],
                Tags = new List<Tag> { tags.Where(t => t.Name == "Life").FirstOrDefault() }
            });

            context.PostContentQuotes.AddOrUpdate(quotes.ToArray());
        }

        private void SeedTags(QuoteversationDbContext context)
        {
            if (context.Tags.Any())
            {
                return;
            }

            List<Tag> tags = new List<Tag> 
            {
                new Tag() { Name = "Fun" },
                new Tag() { Name = "Job" },
                new Tag() { Name = "Hip-hop" },
                new Tag() { Name = "Hurt" },
                new Tag() { Name = "Love" },
                new Tag() { Name = "Metal" },
                new Tag() { Name = "Monday" },
                new Tag() { Name = "Music" },
                new Tag() { Name = "Quote" },
                new Tag() { Name = "Rock" },
                new Tag() { Name = "Whatever" },
                new Tag() { Name = "Work" },
                new Tag() { Name = "Life" },
            };

            context.Tags.AddOrUpdate(tags.ToArray());
            context.SaveChanges();
        }

        private void SeedRoles(QuoteversationDbContext context)
        {
            if (context.Roles.Any())
            {
                return;
            }

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

            context.SaveChanges();
        }

        private byte[] GetSampleImage(string fileName)
        {
            var path = @"C:\Users\yavor\Desktop\Quoteversation\Source\Quoteversation\Quoteversation.Data\Migrations\imgs\";

            var fileContent = File.ReadAllBytes(path + fileName);

            return fileContent;
        }
    }
}
