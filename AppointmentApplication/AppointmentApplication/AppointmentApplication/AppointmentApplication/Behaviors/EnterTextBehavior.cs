using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace AppointmentApplication.AppointmentApplication.Behaviors
{
    public class EntryTextBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += TextEntryChanged;
            base.OnAttachedTo(entry);
            // Perform setup
        }

        private void TextEntryChanged(object sender, TextChangedEventArgs e)
        {
            Entry entry = (Entry)sender;
            if (!string.IsNullOrEmpty(entry.Text))
            {
                string emailRegularExpresion = @"^([A-Z])\w+$";
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
            entry.TextChanged -= TextEntryChanged;
            base.OnDetachingFrom(entry);
        }
    }
}
