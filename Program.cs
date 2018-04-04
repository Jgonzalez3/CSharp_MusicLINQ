using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicLINQ
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();
            //=========================================================
            //There is only one artist in this collection from Mount 
            //Vernon. What is their name and age?
            //=========================================================
            var towns = from match in Artists where match.Hometown == "Mount Vernon" select new {match.RealName, match.Age, match.Hometown};
            foreach( var a in towns){
                System.Console.WriteLine(a);
            }
            //=========================================================
            //Who is the youngest artist in our collection of artists?
            //=========================================================
            var youngest = from match in Artists orderby match.Age ascending select new {match.RealName, match.Age};
            System.Console.WriteLine(youngest.First());
            //=========================================================
            //Display all artists with 'William' somewhere in their 
            //real name        
            //=========================================================
            var william  = from match in Artists where match.RealName.Contains("William") select new {match.RealName};
            foreach( var name in william){
                System.Console.WriteLine(name);
            }
            //=========================================================
            //Display all groups with names less than 8 characters
            //=========================================================
            
            var groupname = from match in Groups select new {match.GroupName}; 
            foreach (var gname in groupname){
                int count = 0;
                for (int i=0; i < gname.GroupName.Length; i++){
                    count++;
                }
                if (count < 8){
                    System.Console.WriteLine(gname.GroupName);
                }
            }
            //=========================================================
            //Display the 3 oldest artists from Atlanta
            //=========================================================
            var altanta = from match in Artists where match.Hometown == "Atlanta" orderby match.Age descending select new {match.RealName, match.Age, match.Hometown};
            int atlcount  = 0;
            foreach ( var name in altanta){
                atlcount++;
                if(atlcount > 3){
                    break;
                }
                System.Console.WriteLine(name);
            }
            //=========================================================
            //(Optional) Display the Group Name of all groups that have 
            //at least one member not from New York City
            //=========================================================
            // var groupny = from match in Groups join Artists in Group on Groups.ID equals Artists.ID select new
            //=========================================================
            //(Optional) Display the artist names of all members of the 
            //group 'Wu-Tang Clan'
            //=========================================================
        }
    }
}
