using System.ComponentModel.DataAnnotations;

namespace Customers.API.Domain
{
    public class Customer
    {
        
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(250)] 
        public string Email { get; set; } = string.Empty;
        public DateOnly BirthDate { get; set; }
    }
}
