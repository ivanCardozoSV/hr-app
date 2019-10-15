using Android.OS;
using Android;
using Microcharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SkiaSharp;

namespace HrApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeView : ContentPage
    {
        public HomeView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var entries = new[]
            {
                new Microcharts.Entry(20)
                {
                    Label = "January",
                    ValueLabel = "20",
                    Color = SKColor.Parse("#266489")
                },
                new Microcharts.Entry(15)
                {
                Label = "February",
                ValueLabel = "15",
                Color = SKColor.Parse("#68B9C0")
                },
                new Microcharts.Entry(33)
                {
                Label = "March",
                ValueLabel = "33",
                Color = SKColor.Parse("#90D585")
                },
                new Microcharts.Entry(12)
                {
                Label = "April",
                ValueLabel = "12",
                Color = SKColor.Parse("#90B585")
                },
                new Microcharts.Entry(40)
                {
                Label = "May",
                ValueLabel = "40",
                Color = SKColor.Parse("#91D585")
                }
            };

            var chart1 = new BarChart() { Entries = entries, LabelTextSize = 35};
            var chart2 = new PointChart() { Entries = entries, LabelTextSize = 35 };
            var chart3 = new LineChart() { Entries = entries, LabelTextSize = 35 };
            var chart4 = new DonutChart() { Entries = entries, LabelTextSize = 35 };
            var chart5 = new RadialGaugeChart() { Entries = entries, LabelTextSize = 35 };
            var chart6 = new RadarChart() { Entries = entries, LabelTextSize = 35 };
            
            this.chart1.Chart = chart1;
            this.chart2.Chart = chart2;
            this.chart3.Chart = chart3;
            this.chart4.Chart = chart4;
            this.chart5.Chart = chart5;
            this.chart6.Chart = chart6;
        }
    }
}