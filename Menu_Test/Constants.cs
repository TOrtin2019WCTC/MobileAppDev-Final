using System;
using System.IO;

namespace Menu_Test
{
    public class Constants
    {
        public static string ApiBase = "https://api.openweathermap.org/data/2.5/";
        public static string WeatherUrl = ApiBase + "weather?q=";
        public static string ApiKey = "&appid=06753bfff56902bacb674ee63e0382b2";
        public static string Units = "&units=imperial";
        public static string CountryCode = "us";

        public const string DatabaseFilename = "TodoSQLite.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFilename);
            }
        }
    }
}
