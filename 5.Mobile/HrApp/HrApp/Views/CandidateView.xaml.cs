using Domain.Model;
using HrApp.API;
using HrApp.API.Beans;
using HrApp.API.Json;
using HrApp.ViewModels;
using Newtonsoft.Json;
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
    public partial class CandidateView : ContentPage
    {
        public CandidateView()
        {
            InitializeComponent();
            //BindingContext = new CandidateViewModel();
          
        }

        private async void OnItemSelected(Object sender, ItemTappedEventArgs e)
        {
            var mydetails = e.Item as CandidatesResponse;
           await Navigation.PushAsync(new CandidateDetailView(mydetails),true);

        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var _container = BindingContext as CandidateViewModel;
            CandidateListView.BeginRefresh();
            if (string.IsNullOrWhiteSpace(e.NewTextValue))
                CandidateListView.ItemsSource = _container.CandidateList;
            else
                CandidateListView.ItemsSource = _container.CandidateList.Where(x => x.Name.ToLower().Contains(e.NewTextValue.ToLower()) || x.LastName.Contains(e.NewTextValue.ToLower()));
            CandidateListView.EndRefresh();
        }
    }
}