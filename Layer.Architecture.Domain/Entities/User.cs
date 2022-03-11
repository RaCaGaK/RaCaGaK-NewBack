using System;
using System.Collections.Generic;

namespace Layer.Architecture.Domain.Entities
{
    public partial class User : BaseEntity
    {
        public User()
        {
            Comments = new HashSet<Comment>();
            MsgFromUserNavigations = new HashSet<Msg>();
            MsgToUserNavigations = new HashSet<Msg>();
            PostReactions = new HashSet<PostReaction>();
            Posts = new HashSet<Post>();
        }

        public string FullName { get; set; } = null!;
        public string NickName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? ImgUrl { get; set; }
        public string Passwd { get; set; } = null!;

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Msg> MsgFromUserNavigations { get; set; }
        public virtual ICollection<Msg> MsgToUserNavigations { get; set; }
        public virtual ICollection<PostReaction> PostReactions { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
