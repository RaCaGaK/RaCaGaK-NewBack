namespace Domain.Entities
{
    public partial class Comment : BaseEntity
    {
        public string Msg { get; set; } = null!;
        public int UserId { get; set; }
        public int PostId { get; set; }

        public virtual Post Post { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}