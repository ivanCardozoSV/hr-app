
using Domain.Model;
using HrApp.API;
using HrApp.API.Beans;
using HrApp.API.DTO;
using HrApp.API.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace HrApp.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        private string message;
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

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
