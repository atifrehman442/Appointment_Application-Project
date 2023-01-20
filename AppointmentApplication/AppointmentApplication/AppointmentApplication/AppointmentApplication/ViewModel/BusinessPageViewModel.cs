using AppointmentApplication.AppointmentApplication.Model;
using AppointmentApplication.AppointmentApplication.View;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace AppointmentApplication.AppointmentApplication.ViewModel
{
    public class BusinessPageViewModel : INotifyPropertyChanged
    {
        private SQLiteConnection con;
        public ClientModel clientmodel;
        public ObservableCollection<ClientModel> Client { get; set; } = new ObservableCollection<ClientModel>();
        public BusinessPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
            con = DependencyService.Get<Iconnect>().GetConnection();
            con.CreateTable<ClientModel>();
            ClientData();
        }

        public Command BookAppointmentCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var businessName = Utils.LogInUser.Firstname + " " + Utils.LogInUser.Lastname;
                    clientmodel = new ClientModel();
                    clientmodel.ClientName = FullName;
                    clientmodel.Date = SelectedDate.ToString("dd/MM/yyyy");
                    clientmodel.Time = SelectTime.ToString();
                    clientmodel.Phone = PhoneNo;
                    clientmodel.Description = Description;
                    clientmodel.BusinessName = businessName;
                    if (FullName != null )
                    {
                       var isInserted= con.Insert(clientmodel);
                        if (isInserted > 0)
                        {
                            Client.Add(clientmodel);
                            await Navigation.PopAsync();
                        }
                        else
                        {
                            await Application.Current.MainPage.DisplayAlert("Alert", "Appointment Not saved", "OK");
                        }                       
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Alert", "Please Enter validinput", "OK");
                    }

                });
            }
        }


        private void ClientData()
        {
            con = DependencyService.Get<Iconnect>().GetConnection();
            var dataWithLinq = con.Table<ClientModel>().ToList();
            var data = (from cli in con.Table<ClientModel>() select cli);
            var businessName = Utils.LogInUser.Firstname + " " + Utils.LogInUser.Lastname;
            var isUser = data.Where(x => x.BusinessName == businessName).ToList();

            foreach (var clit in isUser)
            {
                Client.Add(clit);   
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

        string _fullName;
        public string FullName
        {
            get
            {
                return _fullName;
            }
            set
            {
                _fullName = value;
                OnPropertyChanged();
            }
        }

        string _phoneNo;
        public string PhoneNo
        {
            get
            {
                return _phoneNo;
            }
            set
            {
                _phoneNo = value;
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
