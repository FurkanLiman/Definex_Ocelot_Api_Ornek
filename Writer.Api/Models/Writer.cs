using System.ComponentModel.DataAnnotations;

namespace Writer.Api.Models
{
    public class Writer
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        
        [MaxLength(100)]
        public string? Email { get; set; }
        
        public DateTime CreatedDate { get; set; }
        
        public byte IsActive { get; set; } = 1;
        
        public Writer()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            CreatedDate = DateTime.Now;
        }
        
        public string FullName => $"{FirstName} {LastName}";
    }
}
