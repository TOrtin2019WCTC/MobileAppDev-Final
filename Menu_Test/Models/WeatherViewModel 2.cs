using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Menu_Test.Models
{
    public class WeatherViewModel

    {
       public string City { get; set; }
       public string Temp { get; set; }
       public string Conditions { get; set; }
       public string Image { get; set; }
      


        public WeatherViewModel(string city, string temp, string conditions)
        {
            City = city;
            Temp = temp + "º";
            Conditions = conditions;

            if (Conditions.Contains("rain") || Conditions.Contains("drizzle") || Conditions.Contains("mist"))
            {
                Image = "light-rain.jpg";
            }
            if (Conditions.Contains("thunder"))
            {
                Image = "thunderstorm.png";
            }
            if (Conditions.Contains("cloud"))
            {   

                if (Conditions.Contains("partly"))
                {
                    Image = "partly-cloudy.png";
                }
                else
                {
                    Image = "cloudy.jpg";
                }
                
                
            }

            if (Conditions.Contains("sunny") || Conditions.Contains("clear"))
            {
                Image = "sun-weather.png";
            }

            if (Conditions.Contains("windy"))
            {
                Image = "windy.png";
            }

            if (Conditions.Contains("snow") || Conditions.Contains("flurries"))
            {
                Image = "snow.png";
            }
               
            
        }

        public WeatherViewModel() { }


       
    }
}
