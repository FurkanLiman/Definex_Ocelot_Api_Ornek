using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters")]
        public string Name { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; } = string.Empty;
        
        [Display(Name = "Created Date")]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
    
    public class CategoryListViewModel
    {
        public List<CategoryModel> Categories { get; set; } = new List<CategoryModel>();
    }
} 