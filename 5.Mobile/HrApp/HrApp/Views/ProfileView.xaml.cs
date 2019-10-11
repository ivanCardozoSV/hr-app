using Plugin.GoogleClient.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HrApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfileView : ContentPage
    {
        public ProfileView(GoogleUser googleUser)
        {
            InitializeComponent();
            CachedImage.Source = googleUser.Picture;
            ProfileName.Text = googleUser.Name;
            Email.Text = googleUser.Email;
        }
    }
}