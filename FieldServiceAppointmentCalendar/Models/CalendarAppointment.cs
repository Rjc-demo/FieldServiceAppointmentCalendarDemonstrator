using System;

namespace FieldServiceAppointmentCalendar.Models
{
    public class CalendarAppointment
    {
        public CalendarAppointment(string summary, string location)
        {
            if (string.IsNullOrWhiteSpace(summary))
                throw new ArgumentException("A summary is required.");

            if (string.IsNullOrWhiteSpace(location))
                throw new ArgumentException("A location is required.");


        }
    }
}