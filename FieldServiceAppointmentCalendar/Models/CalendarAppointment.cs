using System;

namespace FieldServiceAppointmentCalendar.Models
{
    public class CalendarAppointment
    {
        public CalendarAppointment(string summary)
        {
            if (string.IsNullOrWhiteSpace(summary))
                throw new ArgumentException("A summary is required.");
        }
    }
}