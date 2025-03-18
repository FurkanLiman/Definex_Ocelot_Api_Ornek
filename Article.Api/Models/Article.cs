using System.ComponentModel.DataAnnotations;

namespace Article.Api.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        
        [Required]
        public string Content { get; set; }
        
        public DateTime PublishedDate { get; set; }
        
        public int? WriterId { get; set; }
        
        public byte IsActive { get; set; } = 1;
        
        public Article()
        {
            Title = string.Empty;
            Content = string.Empty;
            PublishedDate = DateTime.Now;
        }
    }
}
