using Domain.Entities;

namespace Application.Models
{
    public class PostModel
    {
        public int Id { get; set; }
        public string? PostDescription { get; set; }
        public string? ImgUrl { get; set; }
        public bool? IsActive { get; set; }
        public virtual User User { get; set; }
        public int UserID { get; set; }
        public virtual Comment Comment { get; set; }
        public int CommentID { get; set; }
        public virtual PostReaction PostReaction { get; set; }
        public int PostReactionID { get; set; }
    }

    public class CreatePostModel
    {
        public string? PostDescription { get; set; }
        public string? ImgUrl { get; set; }
        public bool? IsActive { get; set; }
        public virtual User User { get; set; }
        public int UserID { get; set; }
        public virtual Comment Comment { get; set; }
        public int CommentID { get; set; }
        public virtual PostReaction PostReaction { get; set; }
        public int PostReactionID { get; set; }
    }

    public class UpdatePostModel : PostModel
    {
    }
}