namespace WebUI.Models
{
    public class HomeViewModel
    {
        public List<ArticleModel> Articles { get; set; } = new List<ArticleModel>();
        public List<WriterModel> Writers { get; set; } = new List<WriterModel>();
        public List<CategoryModel> Categories { get; set; } = new List<CategoryModel>();
    }
} 