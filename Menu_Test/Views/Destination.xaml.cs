using System;
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
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            dsm.SetDestination(destination.Text);
            destination.Text = string.Empty;
        }


    }
}
