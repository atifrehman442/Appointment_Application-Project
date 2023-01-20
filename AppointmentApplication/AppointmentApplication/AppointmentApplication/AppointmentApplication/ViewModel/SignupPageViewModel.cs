using AppointmentApplication.AppointmentApplication.Model;
using AppointmentApplication.AppointmentApplication.View;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace AppointmentApplication.AppointmentApplication.ViewModel
{
    public class SignupPageViewModel : INotifyPropertyChanged
    {
        private SQLiteConnection con;
        public SignupModel signupmodel;
        public SignupPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
            con = DependencyService.Get<Iconnect>().GetConnection();
            con.CreateTable<SignupModel>();
        }

        public Command CommandSignup
        {
            get
            {
                return new Command(async () =>
                {
                    signupmodel = new SignupModel();
                    signupmodel.Firstname = Firstname;
                    signupmodel.Lastname = Lastname;
                    signupmodel.Email = Email;
                    signupmodel.Phone = Phone;
                    signupmodel.Password = Password;
                    signupmodel.picker = picker;
                    var confirm = Confirmpassword;
                    if (Firstname != null)
                    {
                        string FirstnameRegularExpresion = @"^([A-Z])\w+$";
                        bool firstname = Regex.IsMatch(Firstname, FirstnameRegularExpresion);
                        if (firstname)
                        {
                            if (Lastname != null)
                            {
                                string LastnameRegularExpresion = @"^([A-Z])\w+$";
                                bool lastname = Regex.IsMatch(Lastname, LastnameRegularExpresion);
                                if (lastname)
                                {
                                    if (Email != null)
                                    {
                                        string emailRegularExpresion = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
                                        bool email = Regex.IsMatch(Email, emailRegularExpresion);
                                        if (email)
                                        {
                                            if (Phone != null)
                                            {
                                                string PhoneRegularExpresion = @"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{5,6}$";
                                                bool phone = Regex.IsMatch(Phone, PhoneRegularExpresion);
                                                if (phone)
                                                {
                                                    if (confirm == Password)
                                                    {
                                                        con.Insert(signupmodel);
                                                        await Navigation.PushAsync(new Login());
                                                    }
                                                    else
                                                    {
                                                        await Application.Current.MainPage.DisplayAlert("Alert", "Please Enter validPassword", "OK");
                                                    }

                                                }
                                                else
                                                {
                                                    await Application.Current.MainPage.DisplayAlert("Alert", "Please Enter validPhone", "OK");
                                                }
                                            }
                                            else
                                            {
                                                await Application.Current.MainPage.DisplayAlert("Alert", "Please Enter validPhone", "OK");
                                            }
                                        }
                                        else
                                        {
                                            await Application.Current.MainPage.DisplayAlert("Alert", "Please Enter validEmail", "OK");
                                        }
                                    }
                                    else
                                    {
                                        await Application.Current.MainPage.DisplayAlert("Alert", "Please Enter validEmail", "OK");
                                    }
                                }
                                else
                                {
                                    await Application.Current.MainPage.DisplayAlert("Alert", "Please Enter validLastname", "OK");
                                }
                            }
                            else
                            {
                                await Application.Current.MainPage.DisplayAlert("Alert", "Please Enter validLastname", "OK");
                            }
                        }
                        else
                        {
                            await Application.Current.MainPage.DisplayAlert("Alert", "Please Enter validFirstname", "OK");
                        }
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Alert", "Please Enter validFirstname", "OK");
                    }

                });
            }
        }

        string _firstname;
        public string Firstname
        {
            get
            {
                return _firstname;
            }
            set
            {
                _firstname = value;
                OnPropertyChanged();
            }
        }

        string _lastname;
        public string Lastname
        {
            get
            {
                return _lastname;
            }
            set
            {
                _lastname = value;
                OnPropertyChanged();
            }
        }

        string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        string _phone;
        public string Phone
        {
            get
            {
                return _phone;
            }
            set
            {
                _phone = value;
                OnPropertyChanged();
            }
        }

        string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        string _confirmpassword;
        public string Confirmpassword
        {
            get
            {
                return _confirmpassword;
            }
            set
            {
                _confirmpassword = value;
                OnPropertyChanged();
            }
        }

        string _picker;
        public string picker
        {
            get
            {
                return _picker;
            }
            set
            {
                _picker = value;
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
