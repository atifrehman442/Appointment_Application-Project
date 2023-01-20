using AppointmentApplication.AppointmentApplication.Model;
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
    public partial class BusinessPage : ContentPage
    {
        public BusinessPage(SignupModel isUser)
        {
            InitializeComponent();
            this.BindingContext = new BusinessPageViewModel(Navigation);

            Business.Text = isUser.Firstname + " " + isUser.Lastname;
        }

        private void TapGestureLogout(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void TapGestureMyappointment(object sender, EventArgs e)
        {
            var vm = this.BindingContext as BusinessPageViewModel;
            Navigation.PushAsync(new BookAppointmentPage(vm));
        }

    }
}