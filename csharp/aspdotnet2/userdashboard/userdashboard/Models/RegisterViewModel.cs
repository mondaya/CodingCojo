using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
 
namespace userdashboard.Models{
    public class RegisterViewModel {
        [Key]
        public int UserID {get; set;}
        [Required]
        [MinLength(3, ErrorMessage = "First name must be at least 3 characters.")]
        public string FirstName { get; set; }
 
        [Required]
        [MinLength(3, ErrorMessage = "Last name must be at least 3 characters.")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
 
        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string Password_confirmation { get; set; }
    }
}