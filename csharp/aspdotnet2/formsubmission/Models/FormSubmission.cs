using System.ComponentModel.DataAnnotations;

namespace Formsubmission.Models {

    public class FormSubmission : BasEntity {
        
        [RequiredAttribute(ErrorMessage = "First Name is required")]
        [MinLengthAttribute(4)]
        public string FirstName {get; set;}

        [RequiredAttribute(ErrorMessage = "Last Name is required")]
        [MinLengthAttribute(4)]
        public string LastName {get; set;}

        [RequiredAttribute()]
        [RangeAttribute(1,150)]
        public int Age {get; set;}

        [RequiredAttribute]
        [EmailAddressAttribute]
        public string Email {get; set;}

        [RequiredAttribute]
        [MinLengthAttribute(8)]
        public string Password {get; set;}



    }
}