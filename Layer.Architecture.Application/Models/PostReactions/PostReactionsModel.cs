using Layer.Architecture.Domain.Entities;

namespace Layer.Architecture.Application.Models.PostReactions
{
    public class PostReactionsModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public string? ReactionType { get; set; }
        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
    }
    
    public class CreatePostReactionsModel
    {
        public int UserId { get; set; }
        public int PostId { get; set; }
        public string? ReactionType { get; set; }
        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
    }

    public class UpdatePostReactionsModel : PostReactionsModel
    {

    }
}
