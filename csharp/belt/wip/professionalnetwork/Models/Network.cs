using System;
using System.ComponentModel.DataAnnotations;


namespace NetworkProfessional.Models
{

    public class Network : BaseEntity
    {

        [Key]
        public int id { get; set; }

        public bool AcceptedInvite { get; set; }
        public bool IgnoredInvite { get; set; }
        public DateTime CreatedAt { get; set; }
        public int FollowerId { get; set; }
        public Professional Follower { get; set; }        
        public int UserFollowedId { get; set; }
        public Professional UserFollowed { get; set; }

        public Network()
        {
            AcceptedInvite = false;
            IgnoredInvite = false;
            CreatedAt = DateTime.Now;
        }





    }
}