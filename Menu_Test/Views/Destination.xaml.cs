﻿using System;
using System.Collections.Generic;
using Menu_Test.Models;
using Xamarin.Forms;

namespace Menu_Test.Views
{
    public partial class Destination : ContentPage
    {
        DestinationViewModel dsm = new DestinationViewModel();

        public Destination()
        {
            InitializeComponent();
            BindingContext = dsm;
          
            destination.BindingContext = User.Destination;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            destination.BindingContext = User.Destination;
        }

         void Submit_Button_Clicked(System.Object sender, System.EventArgs e)
            
        {
            if(!destination.Text.Equals(string.Empty))
            {
                dsm.SetDestination(destination.Text);
                submit.IsVisible = false;
                destinationInfo.Children.Clear();
                destinationInfo.Children.Add(new Label
                {
                    Text = $"Your destination is {User.Destination}"


                });

                 DisplayAlert("Success!", "Destination is set! \ncheck the Weather Info page to view current weather conditions", "ok");
                
            }
            else
            {
                DisplayAlert("Error", "Enter a Destination", "ok");
            }

           
           
        }

        async void Reset_Button_Clicked(Object sender, EventArgs e)
        {
            User.Destination = string.Empty;
            destination.Text = User.Destination;
            await App.Database.DeleteItemAsync(User.Visited[User.Visited.Count - 1]);
            User.Visited.Remove(User.Visited[User.Visited.Count - 1]);
            User.Visited = await App.Database.GetItemsAsync();
            await DisplayAlert("Success!", "Your Trip Has Been Reset", "Ok");

            
        }


    }
}
