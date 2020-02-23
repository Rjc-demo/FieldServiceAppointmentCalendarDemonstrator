using System;

namespace FieldServiceAppointmentCalendar.Models
{
    public class CalendarAppointment
    {
        public CalendarAppointment(string summary, string location, DateTimeSpan dateRange)
        {
            if (string.IsNullOrWhiteSpace(summary))
                throw new ArgumentException("A summary is required.");

            if (string.IsNullOrWhiteSpace(location))
                throw new ArgumentException("A location is required.");
            
            if (dateRange.Duration.TotalSeconds <= 0)
                throw new ArgumentException("Appointment end must be after start.");

        }
    }
}