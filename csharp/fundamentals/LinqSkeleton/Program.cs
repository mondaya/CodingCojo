using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            //There is only one artist in this collection from Mount Vernon, what is their name and age?
          var artists = from match in Artists
                             where match.Hometown == "Mount Vernon"
                             select match;
            Artist artist = artists.First();
            Console.WriteLine($"The only artist from Mount Veron is {artist.ArtistName} and age is {artist.Age} ");

            //Who is the youngest artist in our collection of artists?
            artists = (from match in Artists
                                orderby match.Age ascending
                                select match).ToList();
            artist = artists.First();
            Console.WriteLine($"The artist with minimun age is {artist.ArtistName} and age is {artist.Age} ");

            //Display all artists with 'William' somewhere in their real name
            artists = (from match in Artists
                                where match.RealName.Contains("William")
                                select match).ToList();
            foreach(Artist entity in artists)
             Console.WriteLine($"The artist {entity.ArtistName} and real name is {entity.RealName}");

            //Display the 3 oldest artist from Atlanta
            Console.WriteLine("Display the 3 oldest artist from Atlanta");
            artists = (from match in Artists
                                orderby match.Age descending
                                where match.Hometown =="Atlanta"
                                select match).ToList().Take(3);
            foreach(Artist entity in artists)
             Console.WriteLine($"The artist {entity.ArtistName} and age is {entity.Age}");

          //(Optional) Display the Group Name of all groups that have members that are not from New York City

           var groups = 
                        (from grp in Groups
                        join person in Artists on  grp.Id equals person.GroupId
                        where person.Hometown != "New York City"
                        select grp).ToList().Distinct();
            foreach(Group entity in groups)            
                Console.WriteLine($"The group {entity.GroupName} ");      


            /*List<string> NonNewYorkGroups = Artists
                                .Join(Groups, artist => artist.GroupId, group => group.Id, (artist, group) => { artist.Group = group; return artist;})
                                .Where(artist => (artist.Hometown != "New York City" && artist.Group != null))
                                .Select(artist => artist.Group.GroupName)
                                .Distinct()
                                .ToList();

            Console.WriteLine("All groups with members not from New York City:");
            foreach(var group in NonNewYorkGroups){
                Console.WriteLine(group);
            }*/
            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
            artists = (from person in Artists 
                                join grp in Groups on  person.GroupId equals grp.Id
                                where grp.GroupName == "Wu-Tang Clan"                                
                                select person).ToList();
            foreach(Artist entity in artists)
             Console.WriteLine($"The artist {entity.ArtistName} and age is {entity.Age}");


            /*  Group WuTang = Groups.Where(group => group.GroupName == "Wu-Tang Clan")
                                    .GroupJoin(Artists, 
                                        group => group.Id,
                                        artist => artist.GroupId,
                                        (group, artists) => { group.Members = artists.ToList(); return group;})
                                    .Single();
            Console.WriteLine("List of Artist in the Wu-Tang Clan:");
            foreach(var artist in WuTang.Members){
                Console.WriteLine(artist.ArtistName);
            }*/

        }
    }
}
