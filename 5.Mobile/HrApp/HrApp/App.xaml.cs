using HrApp.API;
using HrApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HrApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            HttpCommand.Setup("https://hr-app-api.azurewebsites.net/api/");
            HRApi.getApi().Setup("AA", "bb");
            MainPage = new NavigationPage(new CandidateView());
            
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
    }
}
