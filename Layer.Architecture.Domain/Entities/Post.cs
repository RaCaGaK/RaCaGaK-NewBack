using System;
using System.Collections.Generic;

namespace Layer.Architecture.Domain.Entities
{
    public partial class Post : BaseEntity
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
            PostReactions = new HashSet<PostReaction>();
        }

        public string? PostDescription { get; set; }
        public string? ImgUrl { get; set; }
        public bool? IsActive { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<PostReaction> PostReactions { get; set; }
    }
}
