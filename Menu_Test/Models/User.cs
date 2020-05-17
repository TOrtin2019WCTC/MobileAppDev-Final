using System;
using System.Collections.Generic;

namespace Menu_Test.Models
{
    public static class User
    {
        public static List<PlaceVisited> Visited { get; set; }
        public static string Destination { get; set; }

        static User()
        {
            Visited = new List<PlaceVisited>
            {
                new PlaceVisited("Milwaukee"),
                new PlaceVisited("Racine")
            };
            Destination = string.Empty;
        }
    }

    public class PlaceVisited
    {
        public string Location {get; set; }
        public string Date { get; set; }
     
        public PlaceVisited(string location)
        {
           
            this.Location = location;
            DateTime _date = DateTime.Now;
            this.Date = _date.ToShortDateString();

        }
    }
}
