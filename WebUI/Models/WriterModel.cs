using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class WriterModel
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50, ErrorMessage = "First Name cannot be longer than 50 characters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(50, ErrorMessage = "Last Name cannot be longer than 50 characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;
        
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(100, ErrorMessage = "Email cannot be longer than 100 characters")]
        public string? Email { get; set; }
        
        [Display(Name = "Created Date")]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        public byte IsActive { get; set; } = 1;
        
        [Display(Name = "Full Name")]
        public string FullName => $"{FirstName} {LastName}";
    }
    
    public class WriterListViewModel
    {
        public List<WriterModel> Writers { get; set; } = new List<WriterModel>();
    }
} 