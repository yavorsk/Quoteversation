
namespace Quoteversation.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    public static class YouTubeUrlHelpers
    {
        public static string GetEmbedUrl(string watchUrl)
        {
            Regex youTubeVideoRegex = new Regex(@"youtu(?:\.be|be\.com)/(?:(.*)v(/|=)|(.*/)?)([a-zA-Z0-9-_]+)", RegexOptions.IgnoreCase);
            Match youtubeMatch = youTubeVideoRegex.Match(watchUrl);
            string id = string.Empty;
            if (youtubeMatch.Success)
            {
                id = youtubeMatch.Groups[4].Value;
            }
            return "//www.youtube.com/embed/" + id;
        }
    }
}
