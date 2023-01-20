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
    public partial class ClientAppointmentPage : ContentPage
    {
        public ClientAppointmentPage()
        {
            InitializeComponent();
            this.BindingContext = new ClientAppointmentViewModel(Navigation);

        }
    }
}