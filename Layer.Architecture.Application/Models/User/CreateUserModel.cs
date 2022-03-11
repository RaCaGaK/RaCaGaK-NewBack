namespace Layer.Architecture.Application.Models
{
    public class CreateUserModel
    {
        public string FullName { get; set; }
        public string NickName { get; set; }
        public string? ImgUrl { get; set; }
        public string Email { get; set; }
        public string Passwd { get; set; }
    }
}
