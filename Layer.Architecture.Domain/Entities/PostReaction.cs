using System;
using System.Collections.Generic;

namespace Layer.Architecture.Domain.Entities
{
    public partial class PostReaction : BaseEntity
    {
        public int UserId { get; set; }
        public int PostId { get; set; }
        public string? ReactionType { get; set; }

        public virtual Post Post { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
