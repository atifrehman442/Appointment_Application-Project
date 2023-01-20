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
    public partial class ClientAppointmentListPage : ContentPage
    {
        public ClientAppointmentListPage()
        {
            InitializeComponent();
            this.BindingContext = new ClientAppointmentListViewModel();
        }
    }
}