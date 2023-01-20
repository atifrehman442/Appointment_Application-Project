using AppointmentApplication.AppointmentApplication.Model;
using AppointmentApplication.AppointmentApplication.View;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace AppointmentApplication.AppointmentApplication.ViewModel
{
    public class LoginPageViewModel : INotifyPropertyChanged
    {
        private SQLiteConnection con;
        public SignupModel signupmodel;
        private INavigation navigation;
        public LoginPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }

        public Command LoginCommand
        {
            get
            {
                return new Command(async () =>
                {

                    await LogInAsync();
                });
            }
         }

        private async System.Threading.Tasks.Task<bool> LogInAsync()
        {
            con = DependencyService.Get<Iconnect>().GetConnection();
       

            var dataWithLinq = con.Table<SignupModel>().ToList();
            var data = (from sin in con.Table<SignupModel>() select sin);
            var isUser = data.Where(x => x.Email == _enterEmail && x.Password == _enterPassword).FirstOrDefault();
            if (isUser != null)
            {
                var check = isUser.picker;
                Utils.LogInUser = isUser;
                var businessName = Utils.LogInUser.Firstname + " " + Utils.LogInUser.Lastname;
                if (check == "Business")
                {
                    await Navigation.PushAsync(new BusinessPage(isUser));

                }
                else
                {
                    await Navigation.PushAsync(new ClientPage(isUser));
                }
                return true;

            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Alert", "Please Enter validinput", "OK");
                return false;
            }          
        }

        string _enterEmail;
        public string EnterEmail
        {
            get
            {
                return _enterEmail;
            }
            set
            {
                _enterEmail = value;
                OnPropertyChanged();
            }
        }

        string _enterPassword;
        public string EnterPassword
        {
            get
            {
                return _enterPassword;
            }
            set
            {
                _enterPassword = value;
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
