using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BankAccount.Models
{

    public class User : BaseEntity {
        
        [Key]
        public int id {get; set;}

        [Display(Name = "First Name")]
        [RegularExpression(@"^[a-zA-Z''-'\s]+$" , ErrorMessage = "#s or special  Characters are not allowed.")]
        [RequiredAttribute(ErrorMessage = "First Name is required")]
        [MinLengthAttribute(2)]
        public string FirstName {get; set;}
        
        [Display(Name = "Last Name")]
        [RegularExpression(@"^[a-zA-Z''-'\s]+$" , ErrorMessage = "#s or special Characters are not allowed.")]
        [RequiredAttribute(ErrorMessage = "Last Name is required")]
        [MinLengthAttribute(2)]
        public string LastName {get; set;}

        [RequiredAttribute]
        [EmailAddressAttribute]
        public string Email {get; set;}

        [RequiredAttribute]
        [MinLengthAttribute(8)]
        [DataType(DataType.Password)]
        public string Password {get; set;}

        public List<Transaction> Transactions { get; set; }
 
        public User()
        {
            Transactions = new List<Transaction>();
        }






    }
}