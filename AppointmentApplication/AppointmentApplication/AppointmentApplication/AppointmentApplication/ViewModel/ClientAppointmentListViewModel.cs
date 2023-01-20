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

    public class ClientAppointmentListViewModel : INotifyPropertyChanged
    {
        private SQLiteConnection con;
        public ClientModel clientmodel;
        public ObservableCollection<ClientModel> Clients { get; set; } = new ObservableCollection<ClientModel>();
        public ClientAppointmentListViewModel()
        {
            con = DependencyService.Get<Iconnect>().GetConnection();
            con.CreateTable<ClientModel>();
            ClientData();
        }

        private void ClientData()
        {
            con = DependencyService.Get<Iconnect>().GetConnection();


            var dataWithLinq = con.Table<ClientModel>().ToList();
            var data = (from cli in con.Table<ClientModel>() select cli);
            var businessName = Utils.LogInUser.Firstname + " " + Utils.LogInUser.Lastname;
            var isUser = data.Where(x => x.ClientName == businessName).ToList();

            foreach (var clit in isUser)
            {
                Clients.Add(clit);

            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
