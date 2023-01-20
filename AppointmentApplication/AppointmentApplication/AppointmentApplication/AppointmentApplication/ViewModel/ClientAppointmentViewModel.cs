using AppointmentApplication.AppointmentApplication.Model;
using AppointmentApplication.AppointmentApplication.View;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace AppointmentApplication.AppointmentApplication.ViewModel
{
    public class ClientAppointmentViewModel : INotifyPropertyChanged
    {
        private SQLiteConnection con;
        public ClientModel clientmodel;

        public ClientAppointmentViewModel(INavigation navigation)
        {
            con = DependencyService.Get<Iconnect>().GetConnection();
            con.CreateTable<ClientModel>();
            Navigation = navigation;
        }



        public Command ClientAppointmentCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var clientname = Utils.LogInUser.Firstname + " " + Utils.LogInUser.Lastname;
                    var businessName = Utils.BusinessName.Firstname + " " + Utils.BusinessName.Lastname;
                    var phone = Utils.LogInUser.Phone;
                    clientmodel = new ClientModel();
                    clientmodel.ClientName = clientname;
                    clientmodel.Date = SelectedDate.ToString("dd/MM/yyyy");
                    clientmodel.Time = SelectTime.ToString();
                    clientmodel.Phone = phone;
                    clientmodel.Description = Description;
                    clientmodel.BusinessName = businessName;

                     con.Insert(clientmodel);
                     await Navigation.PopAsync();

                });
            }
        }

        DateTime _selectedDate;
        public DateTime SelectedDate
        {
            get
            {
                return _selectedDate;
            }
            set
            {
                _selectedDate = value;
                OnPropertyChanged();
            }
        }

        TimeSpan _selectTime;
        public TimeSpan SelectTime
        {
            get
            {
                return _selectTime;
            }
            set
            {
                _selectTime = value;
                OnPropertyChanged();
            }
        }

        string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

        public INavigation Navigation { get; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
