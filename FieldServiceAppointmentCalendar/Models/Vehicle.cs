using System;

namespace FieldServiceAppointmentCalendar.Models
{
    public class Vehicle
    {
        public Vehicle(string registration)
        {
            Registration = registration;
            Appointments = new Calendar();
        }

        public Calendar Appointments { get; }
        public string Registration { get; }
    }
}