
using Domain.Model;
using HrApp.API;
using HrApp.API.Beans;
using HrApp.API.DTO;
using HrApp.API.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Auth;
using Xamarin.Forms;
using System.Diagnostics;
using Domain.Model;
using Plugin.GoogleClient;
using HrApp.Models;
using Plugin.GoogleClient.Shared;

namespace HrApp.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public UserProfile User { get; set; } = new UserProfile();
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        private string message;
        public bool IsLoggedIn { get; set; }
        public string Token { get; set; }

        public ICommand GoogleLoginCommand { get; set; }
        public ICommand GoogleLogoutCommand { get; set; }
        private readonly IGoogleClientManager _googleClientManager;
        public event PropertyChangedEventHandler PropertyChanged;

        public string Message
        {
            get { return message; }
            set
            {
                if (message == value)
                    return;

                message = value;
                OnPropertyChanged("Message");
            }
        }

        private bool busy = false;

        public bool IsBusy
        {
            get { return busy; }
            set
            {
                if (busy == value)
                    return;

                busy = value;
                OnPropertyChanged("IsBusy");
            }
        }

        public LoginViewModel()
        {
            GoogleLoginCommand = new Command(GoogleLoginAsync);
            GoogleLogoutCommand = new Command(GoogleLogout);

            _googleClientManager = CrossGoogleClient.Current;


            IsLoggedIn = false;
        }

        public ICommand LoginCommand
        {
            get
            {

                return new Command(
                    async () =>
                    {
                        //API ENDPOINT
                        HttpCommand.Setup("https://hr-app-api.azurewebsites.net/api/");
                        HRApi.getApi().Setup(this.UserName,this.Password);

                        var api = HRApi.getApi();
                        var command = new CandidateCommand();
                        var res = api.Execute(command);

                        //var resultss = JsonConvert.DeserializeObject<IEnumerable<Candidate>>(res);

                        var result = JsonConvert.DeserializeObject<CandidatesBeanResponse>(res,
                                CandidateJSONResponseConverter.getInstance());

                    });
            }
        }

        public async void GoogleLoginAsync()
        {
            _googleClientManager.OnLogin += OnGoogleLoginCompleted;
			try 
            {
                await _googleClientManager.LoginAsync();
            }
			catch (GoogleClientSignInNetworkErrorException e)
			{
				await App.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
            }
			catch (GoogleClientSignInCanceledErrorException e)
            {
                await App.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
            }
			catch (GoogleClientSignInInvalidAccountErrorException e)
            {
                await App.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
            }
			catch (GoogleClientSignInInternalErrorException e)
            {
                await App.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
            }
            catch (GoogleClientNotInitializedErrorException e)
            {
                await App.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
            }
			catch (GoogleClientBaseException e)
            {
                await App.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
            }
        }

        private void OnGoogleLoginCompleted(object sender, GoogleClientResultEventArgs<GoogleUser> loginEventArgs)
        {
            if (loginEventArgs.Data != null)
            {
                GoogleUser googleUser = loginEventArgs.Data;
                User.Name = googleUser.Name;
                User.Email = googleUser.Email;
                User.Picture = googleUser.Picture;
                var GivenName = googleUser.GivenName;
                var FamilyName = googleUser.FamilyName;


                // Log the current User email
                Debug.WriteLine(User.Email);
                IsLoggedIn = true;
                OnPropertyChanged("IsLoggedIn");

                var token = CrossGoogleClient.Current.ActiveToken;
                Token = token;
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Error", loginEventArgs.Message, "OK");
            }

            _googleClientManager.OnLogin -= OnGoogleLoginCompleted;

        }

        public void GoogleLogout()
        {
            _googleClientManager.OnLogout += OnGoogleLogoutCompleted;
            _googleClientManager.Logout();
        }

        private void OnGoogleLogoutCompleted(object sender, EventArgs loginEventArgs)
        {
            IsLoggedIn = false;
            OnPropertyChanged("IsLoggedIn");
            User.Email = "Offline";
            _googleClientManager.OnLogout -= OnGoogleLogoutCompleted;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
