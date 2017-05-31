using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace userdashboard.Models{
    public class User {
        [Key]
        public int UserID {get; set; }
        public string FirstName {get; set; }
        public string LastName {get; set; }
        public string Email {get; set; }
        public string Password {get; set; }

        public User() {
            ReceivedMessages = new List<Message>();
            SentMessages = new List<Message>();
            Comments = new List<Comment>();
        }

        [InverseProperty("MessageReciever")]
        public List<Message> ReceivedMessages {get; set; }

         [InverseProperty("MessageSender")]
        public List<Message> SentMessages {get; set; }

        public List<Comment> Comments {get; set; }
    }
}