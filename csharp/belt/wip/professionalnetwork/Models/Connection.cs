namespace NetworkProfessional.Models
{

    public class Connection : BaseEntity {
        
        public int ConnectionId {get;set;}
        public Professional Follower { get; set; }
        public bool FollowerInvited {get;set;}

        public Professional Followed { get; set; }
        public bool AcceptedInvite { get; set; }
        public bool IgnoredInvite { get; set; }
        public Connection(){

        }
        public Connection(Professional follower,  Professional followed, bool acceptedInvite, bool ignoredInvite) {      
            AcceptedInvite = acceptedInvite;
            IgnoredInvite = ignoredInvite;
            Follower = follower;
            Followed = followed;
        }
    }
}