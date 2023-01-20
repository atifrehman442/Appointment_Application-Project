
using AppointmentApplication.AppointmentApplication.View;
using AppointmentApplication.CalculaterApp;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppointmentApplication
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new CalculaterPage())
            {

                BarBackgroundColor = Color.FromHex("#c54c82")
            };
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
