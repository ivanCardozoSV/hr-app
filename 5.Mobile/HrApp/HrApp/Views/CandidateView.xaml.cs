using HrApp.API;
using HrApp.API.Beans;
using HrApp.API.Json;
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
            GetCandidates();

        }

        public void GetCandidates()
        {

            var api = HRApi.getApi();
            var command = new CandidateCommand();
         var res = api.Execute(command);

            //var resultss = JsonConvert.DeserializeObject<IEnumerable<Candidate>>(res);

            var result = JsonConvert.DeserializeObject<CandidatesBeanResponse>(res,
                    CandidateJSONResponseConverter.getInstance());

            CandidateViw.ItemsSource = result.Candidates;
        }
    }
}