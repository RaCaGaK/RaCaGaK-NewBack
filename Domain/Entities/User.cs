using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class User : BaseEntity
    {
        protected User()
        {
        }

        public User(string fullName, string nickName, string email, string imgUrl, string passwd)
        {
            FullName = fullName;
            NickName = nickName;
            Email = email;
            ImgUrl = imgUrl;
            Passwd = passwd;
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