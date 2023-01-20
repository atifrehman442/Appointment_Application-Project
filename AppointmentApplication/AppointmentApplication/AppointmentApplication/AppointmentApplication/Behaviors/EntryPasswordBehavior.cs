using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace AppointmentApplication.AppointmentApplication.Behaviors
{
    public class EntryPasswordBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += PasswordEntryChanged;
            base.OnAttachedTo(entry);
            // Perform setup
        }

        private void PasswordEntryChanged(object sender, TextChangedEventArgs e)
        {
            Entry entry = (Entry)sender;
            if (!string.IsNullOrEmpty(entry.Text))
            {
                string emailRegularExpresion = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$";
                bool isMacthed = Regex.IsMatch(entry.Text, emailRegularExpresion);
                if (isMacthed)
                {
                    entry.TextColor = Color.Black;
                }
                else
                {
                    entry.TextColor = Color.Red;
                }
            }
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= PasswordEntryChanged;
            base.OnDetachingFrom(entry);
        }
    }
}
