using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class ArticleModel
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Title is required")]
        [StringLength(200, ErrorMessage = "Title cannot be longer than 200 characters")]
        public string Title { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Content is required")]
        public string Content { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Writer is required")]
        public int WriterId { get; set; }
        public string WriterName { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Category is required")]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        
        [Display(Name = "Created Date")]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        [Display(Name = "Published Date")]
        [DataType(DataType.DateTime)]
        public DateTime PublishedDate { get; set; } = DateTime.Now;
        
        public byte IsActive { get; set; } = 1;
    }
    
    public class ArticleListViewModel
    {
        public List<ArticleModel> Articles { get; set; } = new List<ArticleModel>();
    }
} 