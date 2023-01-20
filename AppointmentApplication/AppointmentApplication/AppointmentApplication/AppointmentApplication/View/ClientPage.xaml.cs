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
    public partial class ClientPage : ContentPage
    {
        public ClientPage(SignupModel isUser)
        {
            InitializeComponent();

            this.BindingContext = new ClientPageViewModel(Navigation);
            clientname.Text = isUser.Firstname + " " + isUser.Lastname;


        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Utils.LogInUser = null;
            Navigation.PopAsync();
        }

        async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var client = e.SelectedItem as SignupModel;
            if (client == null)
            {
                return;
            }
            Utils.BusinessName = client;
            
            await Navigation.PushAsync(new ClientAppointmentPage());
        }

        private void TapGestureAppoinment(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ClientAppointmentListPage());
        }
    }
}