using HrApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HrApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabbedPage1 : Xamarin.Forms.TabbedPage
    {
        public TabbedPage1()
        {
            SetValue(NavigationPage.HasNavigationBarProperty, false);
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
            InitializeComponent();
        }

    }
}

