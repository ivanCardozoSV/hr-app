
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
//using Domain.Model;
using Plugin.GoogleClient;
using HrApp.Models;
using Plugin.GoogleClient.Shared;
using HrApp.Views;
using HrApp.Services.Interfaces;

namespace HrApp.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public UserProfile User { get; set; } = new UserProfile();
        public GoogleUser googleUser { get; set; } = new GoogleUser();
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        private string message;
        public bool IsLoggedIn { get; set; }

        private ILoginService _loginService;

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

        public LoginViewModel(ILoginService loginService)
        {
            _loginService = loginService;
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
                        Application.Current.Properties[Constants.ValidatedUserToken] = _loginService.Authenticate(this.UserName, this.Password);

                        IsLoggedIn = true;
                        OnPropertyChanged("IsLoggedIn");

                        if (IsLoggedIn)
                        {
                          Application.Current.MainPage = new NavigationPage(new TabbedPage1(googleUser));
                        }
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

        private async void OnGoogleLoginCompleted(object sender, GoogleClientResultEventArgs<GoogleUser> loginEventArgs)
        {
            try
            {
                if (loginEventArgs.Data != null)
                {
                    googleUser = loginEventArgs.Data;
                    User.Name = googleUser.Name;
                    User.Email = googleUser.Email;
                    User.Picture = googleUser.Picture;
                    var GivenName = googleUser.GivenName;
                    var FamilyName = googleUser.FamilyName;

                    var token = CrossGoogleClient.Current.ActiveToken;
                    Application.Current.Properties[Constants.ValidatedUserToken] = _loginService.AuthenticateExternal(token);

                    IsLoggedIn = true;
                    OnPropertyChanged("IsLoggedIn");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", loginEventArgs.Message, "OK");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                _googleClientManager.OnLogin -= OnGoogleLoginCompleted;
                if (IsLoggedIn)
                    await Application.Current.MainPage.Navigation.PushAsync(new TabbedPage1(googleUser));
            }

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
