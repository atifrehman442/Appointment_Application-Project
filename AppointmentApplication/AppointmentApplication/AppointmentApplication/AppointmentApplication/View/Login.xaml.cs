
using AppointmentApplication.AppointmentApplication.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppointmentApplication.AppointmentApplication.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
            this.BindingContext = new LoginPageViewModel(Navigation);
        }

        private void TapGestureLogin(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignUp());
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            var imageButton = sender as ImageButton;
            if (MyEntry.IsPassword)
            {
                imageButton.Source = ImageSource.FromFile("eyeon.png");
                MyEntry.IsPassword = false;
            }
            else
            {
                imageButton.Source = ImageSource.FromFile("eyeoff.png");
                MyEntry.IsPassword = true;
            }
        }
    }
}