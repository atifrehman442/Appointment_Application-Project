using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace AppointmentApplication.AppointmentApplication.Behaviors
{
    class EntryPhoneBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += PhoneChanged;
            base.OnAttachedTo(entry);
        }

        private void PhoneChanged(object sender, TextChangedEventArgs e)
        {
            Entry entry = (Entry)sender;
            if (!string.IsNullOrEmpty(entry.Text))
            {
                string PhoneRegularExpresion = @"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{5,6}$";
                bool isMacthed = Regex.IsMatch(entry.Text, PhoneRegularExpresion);
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
            entry.TextChanged -= PhoneChanged;
            base.OnDetachingFrom(entry);
        }
    }
}
