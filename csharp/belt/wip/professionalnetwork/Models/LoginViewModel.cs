using System.ComponentModel.DataAnnotations;

namespace NetworkProfessional.Models
{

    public class LoginViewModel : BaseEntity {
        
        [Key]    

       
        [RequiredAttribute]
        [EmailAddressAttribute]
        public string Email {get; set;}

        [RequiredAttribute]
        [MinLengthAttribute(8)]
        [DataType(DataType.Password)]
        public string Password {get; set;}




    }
}