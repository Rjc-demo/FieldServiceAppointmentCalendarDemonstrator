using System;

namespace FieldServiceAppointmentCalendar.Models
{
    public class CalendarAppointment
    {
        private readonly string summary;
        private readonly string location;
        private readonly DateTimeSpan dateRange;

        public CalendarAppointment(string summary, string location, DateTimeSpan dateRange)
        {
            if (string.IsNullOrWhiteSpace(summary))
                throw new ArgumentException("A summary is required.");

            if (string.IsNullOrWhiteSpace(location))
                throw new ArgumentException("A location is required.");
            
            if (!dateRange.HasValidRange)
                throw new ArgumentException("Appointment end must be after start.");
            this.summary = summary;
            this.location = location;
            this.dateRange = dateRange;
        }

        public DateTimeSpan DateRange => dateRange;

        internal bool IsIncompatibleWith(CalendarAppointment existingAppointment)
        {
            return DateRange.Intersects(existingAppointment.DateRange);
        }


    }
}