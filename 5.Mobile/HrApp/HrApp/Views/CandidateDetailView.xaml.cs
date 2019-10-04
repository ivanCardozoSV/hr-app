using HrApp.API.Beans;
using HrApp.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HrApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CandidateDetailView : ContentPage
    {
        private CandidatesResponse candidate = new CandidatesResponse();

        public CandidateDetailView(CandidatesResponse candidate)
        {
            InitializeComponent();
            this.candidate = candidate;
            Name.Text = "Name: " +candidate.Name+" "+ candidate.LastName;
            DNI.Text = "DNI: "+candidate.DNI.ToString();
            PhoneNumber.Text = candidate.PhoneNumber;
            AdditionalInformation.Text =   (candidate.AdditionalInformation == null)? "" : candidate.AdditionalInformation.ToString();
            EnglishLevel.Text = candidate.EnglishLevel.ToString();
            ContactDay.Text = candidate.ContactDay.ToString() ; 

        }

        private void OnButtonEmailClicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("mailto:" + candidate.EmailAddress));
    
        }

        private void OnButtonLinkedinClicked(object sender, EventArgs e)
        {
              if (candidate.LinkedInProfile!=null && candidate.LinkedInProfile!="")
                Device.OpenUri(new Uri(candidate.LinkedInProfile));
              else
                DependencyService.Get<IToastMessage>().LongAlert("There is no linkedin profile");
        }
    }
}
