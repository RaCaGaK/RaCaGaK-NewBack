namespace Layer.Architecture.Domain.Models
{
    public class TemplateModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? PostDescription { get; set; }
        public string ImgUrl { get; set; }
    }
    public class CreateTemplateModel
    {
        public string Title { get; set; }
        public string? PostDescription { get; set; }
        public string ImgUrl { get; set; }
    }

    public class UpdateTemplateModel : TemplateModel
    {
    }
}
