using System;
using System.Collections.Generic;
using System.Diagnostics;
using SQLite;

namespace Menu_Test.Models
{
    public static class User
    {

        public static List<PlaceVisited> Visited { get; set; }
        public static string Destination { get; set; }

        static User()
        {
           
            Destination = string.Empty;
        }



    }



    public class PlaceVisited
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Location { get; set; }
        public string Date { get; set; }
        //public WeatherInfo WeatherInfo { get; set; }

        public PlaceVisited(string location)
        {

            this.Location = location;
            DateTime _date = DateTime.Now;
            this.Date = _date.ToShortDateString();

        }

        public PlaceVisited() { }
    }
}
