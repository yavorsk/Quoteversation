namespace Quoteversation.Web.ViewModels.Tags
{
    using Quoteversation.Models;
    using Quoteversation.Web.Infrastructure.Mapping;

    public class TagViewModel : IMapFrom<Tag>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}