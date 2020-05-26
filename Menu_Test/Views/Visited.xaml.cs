using System;
using System.Collections.Generic;
using Menu_Test.Models;
using Xamarin.Forms;

namespace Menu_Test
{
    public partial class Visited : ContentPage
    {
        
        public Visited()
        {
            InitializeComponent();
        }

        async protected override void OnAppearing()
        {
            base.OnAppearing();
            visited.ItemsSource = await App.Database.GetItemsAsync();
            
        }

        async void Delete_Button_Clicked(System.Object sender, System.EventArgs e)
        {
            var button = (Button)sender;

            if(button.CommandParameter != null)
            {
                var placeVisited = (PlaceVisited)button.CommandParameter;
                await App.Database.DeleteItemAsync(placeVisited);
                User.Visited.Remove(placeVisited);
                
                OnAppearing();

            }
        }
    }
}
