using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentApplication.AppointmentApplication.Model
{
    public class SignupModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string picker { get; set; }
    }
}
