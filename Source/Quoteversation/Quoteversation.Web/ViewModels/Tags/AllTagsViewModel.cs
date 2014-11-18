namespace Quoteversation.Web.ViewModels.Tags
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class AllTagsViewModel
    {
        public ICollection<TagViewModel> Tags { get; set; }
    }
}