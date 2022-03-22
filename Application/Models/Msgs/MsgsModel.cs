using System;
using Domain.Entities;

namespace Application.Models
{
    public class MsgsModel
    {
        public string Id { get; set; }
        public string Msg1 { get; set; }
        public DateTime SentDate { get; set; }
        public bool? IsRead { get; set; }
        public int FromUser { get; set; }
        public int ToUser { get; set; }
        public virtual User FromUserNavigation { get; set; }
        public virtual User ToUserNavigation { get; set; }
    }

    public class CreateMsgsModel
    {
        public string Msg1 { get; set; }
        public DateTime SentDate { get; set; }
        public bool? IsRead { get; set; }
        public int FromUser { get; set; }
        public int ToUser { get; set; }
        public virtual User FromUserNavigation { get; set; }
        public virtual User ToUserNavigation { get; set; }
    }

    public class UpdateMsgsModel : MsgsModel
    {
    }
}