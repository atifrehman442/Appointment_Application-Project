﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AppointmentApplication.AppointmentApplication;
using AppointmentApplication.Droid;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(Sqlitedb))]
namespace AppointmentApplication.Droid
{
    public class Sqlitedb : Iconnect
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