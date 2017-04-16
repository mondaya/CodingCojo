using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NetworkProfessional.Models;


namespace NetworkProfessional
{

    public class NetworkProfessionalContext : DbContext{
        
        // base() calls the parent class' constructor passing the "options" parameter along
        public NetworkProfessionalContext(DbContextOptions<NetworkProfessionalContext> options):base(options){

        }
       
        public DbSet<Professional> Professionals { get; set; }   
        public DbSet<Network> Networks { get; set; }
        public List<Connection> GetAllMyConnections(int userLoginId){
            var followedByList = this.Networks                    
                        .Where(network => network.UserFollowedId == userLoginId)
                        .Include(network => network.Follower)
                        .Select(network => new Connection{
                            ConnectionId = network.id,
                            Follower = network.Follower, 
                            FollowerInvited = false,
                            Followed = null, 
                            AcceptedInvite = network.AcceptedInvite, 
                            IgnoredInvite = network.IgnoredInvite
                            });
                       

            var userFollowedList = this.Networks
                        .Where(network => network.FollowerId == (int)userLoginId)
                        .Include(network => network.UserFollowed)
                        .Select(network => new Connection{
                            ConnectionId = network.id,
                            Follower = network.UserFollowed,
                            FollowerInvited = true,
                            Followed = null, 
                            AcceptedInvite = network.AcceptedInvite, 
                            IgnoredInvite = network.IgnoredInvite
                            });
                      
            
            List<Connection> PeopleInUserNetwork = new List<Connection>();

            
            foreach (Connection p in followedByList)
            {
                PeopleInUserNetwork.Add(p);
            }

            foreach (Connection p in userFollowedList)
            {
                PeopleInUserNetwork.Add(p);
            }
            return (PeopleInUserNetwork);
        }
    }
}