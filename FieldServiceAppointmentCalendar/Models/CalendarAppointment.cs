using System;
using System.ComponentModel.DataAnnotations;

namespace FieldServiceAppointmentCalendar.Models
{
    public class CalendarAppointment
    {
        public CalendarAppointment()
        {

        }

        public CalendarAppointment(string summary, string location, DateTimeSpan dateRange)
        {
            if (string.IsNullOrWhiteSpace(summary))
                throw new ArgumentException("A summary is required.");

            if (string.IsNullOrWhiteSpace(location))
                throw new ArgumentException("A location is required.");
            
            if (!dateRange.HasValidRange)
                throw new ArgumentException("Appointment end must be after start.");
            this.Summary = summary;
            this.Location = location;
            this.DateRange = dateRange;
        }

        public DateTimeSpan DateRange { get; set; }

        [StringLength(255)]
        public string Location { get; set; }

        [StringLength(255)]
        public string Summary { get; set; }

        internal bool IsIncompatibleWith(CalendarAppointment existingAppointment)
        {
            return DateRange.Intersects(existingAppointment.DateRange);
        }
        
        [Key]
        public Guid ID { get; set; }
    }
}