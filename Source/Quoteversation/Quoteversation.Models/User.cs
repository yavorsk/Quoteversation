namespace Quoteversation.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Quoteversation.Data.Common.Models;

    public class User : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public User()
        {
            // This will prevent UserManager.CreateAsync from causing exception
            this.CreatedOn = DateTime.Now;

            this.UploadedPics = new HashSet<PostContentPic>();
            this.UploadedQuotes = new HashSet<PostContentQuote>();
            this.UploadedVideos = new HashSet<PostContentVideo>();

            this.CreatedConversations = new HashSet<Conversation>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<PostContentQuote> UploadedQuotes { get; set; }

        public virtual ICollection<PostContentPic> UploadedPics { get; set; }

        public virtual ICollection<PostContentVideo> UploadedVideos { get; set; }

        public virtual ICollection<Conversation> CreatedConversations { get; set; }
    }
}
