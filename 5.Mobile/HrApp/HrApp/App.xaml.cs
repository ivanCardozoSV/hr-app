using Autofac;
using HrApp.API;
using HrApp.Services;
using HrApp.Services.Interfaces;
using HrApp.Views;

using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HrApp
{
    public partial class App : Application
    {
        ObservableCollection<string> Items;
        bool isLoading;
        Page page;

        public App()
        {
            InitializeComponent();
            Items = new ObservableCollection<string>();
            var listview = new ListView();

            listview.ItemsSource = Items;
            listview.ItemAppearing += (sender, e) =>
            {
                if (isLoading || Items.Count == 0)
                    return;

                //hit bottom!
                if (e.Item.ToString() == Items[Items.Count - 1])
                {
                    LoadItems();
                }
            };

            // The root page of your application
            page = new ContentPage
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
                        listview
                    }
                }
            };


            HttpCommand.Setup(Constants.APIEndpoint);
            HRApi.getApi().Setup("AA", "bb");
            MainPage = new NavigationPage(new TabbedPage1());
            LoadItems();
        }

        protected override void OnStart()
        {
    
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }


        private async Task LoadItems()
        {
            isLoading = true;
            page.Title = "Loading";

            //simulator delayed load
            Device.StartTimer(TimeSpan.FromSeconds(2), () => {
                for (int i = 0; i < 20; i++)
                {
                    Items.Add(string.Format("Item {0}", Items.Count));
                }
                page.Title = "Done";
                isLoading = false;
                //stop timer
                return false;
            });
        }

    }
}
