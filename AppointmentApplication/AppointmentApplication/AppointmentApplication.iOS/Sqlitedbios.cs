using AppointmentApplication.AppointmentApplication;
using AppointmentApplication.iOS;
using Foundation;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(Sqlitedbios))]
namespace AppointmentApplication.iOS
{
    public class Sqlitedbios : Iconnect
    {
        public SQLiteConnection GetConnection()
        {
            var dbName = "mydatabase.sqlite";
            var dbPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            var path = Path.Combine(dbPath, dbName);
            var con = new SQLiteConnection(path);
            return con;
        }
    }
}