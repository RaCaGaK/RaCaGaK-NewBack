using System;

namespace Domain.Entities
{
    public partial class Msg : BaseEntity
    {
        public string Msg1 { get; set; } = null!;
        public DateTime SentDate { get; set; }
        public bool? IsRead { get; set; }
        public int FromUser { get; set; }
        public int ToUser { get; set; }

        public virtual User FromUserNavigation { get; set; } = null!;
        public virtual User ToUserNavigation { get; set; } = null!;
    }
}