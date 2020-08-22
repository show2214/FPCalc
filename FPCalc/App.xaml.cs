using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FPCalc
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var page = new NavigationPage(new MainPage());
            page.BarBackgroundColor = Color.LightGreen;
            MainPage = page;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
