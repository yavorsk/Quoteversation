using Quoteversation.Data.Common.Models;

namespace Quoteversation.Models
{
    using System.ComponentModel.DataAnnotations;

    using Quoteversation.Data.Common.Models;

    public class VideoPost : Post
    {
        public VideoPost()
        {
            this.Likes = new HashSet<Like>();
        }

        [Required]
        public string VideoUrl { get; set; }

        [MaxLength(60)]
        public string SongTitle { get; set; }

        [MaxLength(60)]
        public string Artist { get; set; }

        public virtual ICollection<Like> Likes { get; set; }
    }
}
