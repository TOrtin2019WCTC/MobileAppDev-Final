using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Menu_Test.Models;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace Menu_Test
{
    public partial class Weather : ContentPage
    {
        public HttpClient _client = new HttpClient();
        public  WeatherViewModel weather = new WeatherViewModel();

        public Weather()
        {
           
 
            InitializeComponent();


        }

        

        
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            if(User.Destination.Equals(string.Empty))
            {
                weather_info.Children.Add(new Label { Text = "No Destination Selected" });
            }
            else
            {
                await GetWeatherInfo();
                BindingContext = weather;
                

            }
            
        }


        public async Task GetWeatherInfo()
        {


            var uri = new Uri($"{Constants.WeatherUrl}{User.Destination},{Constants.CountryCode}{Constants.Units}{Constants.ApiKey}");
            Debug.WriteLine(uri);
            //var uri = new Uri($"https://api.openweathermap.org/data/2.5/weather?q=brookfield,wi,us&units=imperial&appid=06753bfff56902bacb674ee63e0382b2");
            try
            {
                var response = await _client.GetAsync(uri);
                Debug.WriteLine(response);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    JObject obj = JObject.Parse(content);
                    int _temp = (int)obj["main"]["temp"];
                    string temp = _temp.ToString();
                    string conditions = (string)obj["weather"][0]["description"];
                    
                    //string main = (string)arr[1]["main"];
                    string city = (string)obj["name"];

                    

                    Debug.WriteLine("Temp: " + temp + "º");

                    weather = new WeatherViewModel(city, temp, conditions);


                }
                else
                {
                    await DisplayAlert("Yeah, no", "City doesn't exist", "OK");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ERROR: " + ex.Message);
                
            }

          

          
        }
    }
}

