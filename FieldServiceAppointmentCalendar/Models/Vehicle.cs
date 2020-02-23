using System;

namespace FieldServiceAppointmentCalendar.Models
{
    public class Vehicle
    {
        public Vehicle()
        {
            Appointments = new Calendar();
        }

        public Calendar Appointments { get; }
    }
}