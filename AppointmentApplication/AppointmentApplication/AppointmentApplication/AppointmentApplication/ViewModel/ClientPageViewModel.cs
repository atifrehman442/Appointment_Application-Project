using AppointmentApplication.AppointmentApplication.Model;
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
    public class ClientPageViewModel : INotifyPropertyChanged
    {
        private SQLiteConnection con;
        public SignupModel signupmodel;
        private INavigation navigation;
        public ObservableCollection<SignupModel> Business { get; set; } = new ObservableCollection<SignupModel>();

        public ClientPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
            LogIn();
        }

        private void LogIn()
        {
            con = DependencyService.Get<Iconnect>().GetConnection();


            var dataWithLinq = con.Table<SignupModel>().ToList();
            var data = (from sin in con.Table<SignupModel>() select sin);
            var isUser = data.Where(x => x.picker == "Business").ToList();

            foreach (var bus in isUser)
            {
                Business.Add(bus);
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
