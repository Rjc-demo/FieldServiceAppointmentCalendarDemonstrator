using System;

namespace FieldServiceAppointmentCalendar.Models
{
    public class DateTimeSpan
    {
        private DateTime start;
        private DateTime end;

        public DateTimeSpan(DateTime start, DateTime end)
        {
            this.start = start;
            this.end = end;
        }

        public TimeSpan Duration
        {
            get
            {
                return end - start;
            }
        }
    }
}