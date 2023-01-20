using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace AppointmentApplication.Droid
{
    [Activity(Theme = "@style/Theme.Splash",
    MainLauncher = true,
    NoHistory = true,
    Icon = "@drawable/splash1")]
    //[Activity(Label = "SplashActivity")]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Timer timer = new Timer();
            timer.Interval = 10;
            timer.AutoReset = false; // Do not reset the timer after it's elapsed
            timer.Elapsed += (object sender, ElapsedEventArgs e) =>
            {
                StartActivity(typeof(MainActivity));
            };
            timer.Start();

            // Create your application here
        }
    }
}