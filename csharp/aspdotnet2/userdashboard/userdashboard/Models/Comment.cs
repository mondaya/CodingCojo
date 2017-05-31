namespace userdashboard.Models {
    public class Comment{
        public int CommentID {get; set; }
        public string CommentContent {get; set; }
        public int MessageID {get; set; }
        public Message Message {get; set; }
        public int UserID {get; set; }
        public User User {get; set; }
    }
}