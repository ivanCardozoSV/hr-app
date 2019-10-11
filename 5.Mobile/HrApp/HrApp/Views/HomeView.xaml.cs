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
                new Microcharts.Entry(400)
                {
                    Label = "January",
                    ValueLabel = "200",
                    Color = SKColor.Parse("#266489")
                },
                new Microcharts.Entry(400)
                {
                Label = "February",
                ValueLabel = "400",
                Color = SKColor.Parse("#68B9C0")
                },
                new Microcharts.Entry(-100)
                {
                Label = "March",
                ValueLabel = "-100",
                Color = SKColor.Parse("#90D585")
                }
            };

            var chart1 = new BarChart() { Entries = entries };
            var chart2 = new PointChart() { Entries = entries };
            var chart3 = new LineChart() { Entries = entries };
            var chart4 = new DonutChart() { Entries = entries };
            var chart5 = new RadialGaugeChart() { Entries = entries };
            var chart6 = new RadarChart() { Entries = entries };
            
            this.chart1.Chart = chart1;
            this.chart2.Chart = chart2;
            this.chart3.Chart = chart3;
            this.chart4.Chart = chart4;
            this.chart5.Chart = chart5;
            this.chart6.Chart = chart6;
        }
    }
}