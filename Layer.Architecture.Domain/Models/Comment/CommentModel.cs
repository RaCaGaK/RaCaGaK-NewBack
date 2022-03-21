using Layer.Architecture.Domain.Entities;

namespace Layer.Architecture.Domain.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public string Msg { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public virtual User User { get; set; }
        public virtual Post Post { get; set; } 
    }

    public class CreateCommentModel
    {
        public string Msg { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public virtual User User { get; set; }
        public virtual Post Post { get; set; }
    }

    public class UpdateCommentModel : CommentModel
    {

    }
}
