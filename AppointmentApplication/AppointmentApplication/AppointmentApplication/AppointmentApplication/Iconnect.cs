using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentApplication.AppointmentApplication
{
    public interface Iconnect
    {
        SQLiteConnection GetConnection();
    }
}
