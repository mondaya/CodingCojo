using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace userdashboard.Models {
    public class Message{
        public int MessageId {get; set;}
        public string MessageContent { get; set; }

        public int MessageSenderID {get; set; }
        public User MessageSender {get; set; }
        
        public int MessageRecieverID {get; set; }
        public User MessageReciever {get; set; }
        public DateTime CreatedAt {get; set; }

        public List<Comment> comments {get; set; }
        public DateTime createdat {get; set; }
    }        


}