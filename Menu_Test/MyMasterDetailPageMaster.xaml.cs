using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Menu_Test.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Menu_Test
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyMasterDetailPageMaster : ContentPage
    {
        public ListView ListView;

        public MyMasterDetailPageMaster()
        {
            InitializeComponent();

            BindingContext = new MyMasterDetailPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MyMasterDetailPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MyMasterDetailPageMenuItem> MenuItems { get; set; }

            public MyMasterDetailPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<MyMasterDetailPageMenuItem>(new[]
                {
                    new MyMasterDetailPageMenuItem { Id = 0, Title = "Destination", TargetType = typeof(Destination), Image = "compass.png" },
              
                    new MyMasterDetailPageMenuItem { Id = 1, Title = "Weather Info", TargetType = typeof(Weather), Image = "sun.png" },

                    new MyMasterDetailPageMenuItem { Id = 2, Title = "Places Visited", TargetType = typeof(Visited), Image = "location.png" }
                    
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}
