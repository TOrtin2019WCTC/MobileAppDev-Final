using System;
using System.Collections.Generic;
using System.Diagnostics;
using Menu_Test.Data;
using Menu_Test.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Menu_Test
{
    public partial class App : Application
    {
        static UserDatabase db;
        
        public App()
        {
            SetVisited();
            InitializeComponent();
          
            MainPage = new MyMasterDetailPage();
        }


        public static UserDatabase Database
        {
            get
            {
                if(db == null)
                {
                    db = new UserDatabase();
                }


                return db;
            }
        }


        public static async void SetVisited()
        {
            if (App.Database.GetItemsAsync() != null)
            {
                User.Visited = await App.Database.GetItemsAsync();
            }
            else
            {

                Debug.WriteLine("ERRORXXXXXXX: Db is Null");
            //    User.Visited = new List<PlaceVisited>
            //{
            //    new PlaceVisited("Milwaukee"),
            //    new PlaceVisited("Racine")
            //};

                foreach (PlaceVisited visited in User.Visited)
                {
                    await App.Database.SaveItemAsync(visited);
                }
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
