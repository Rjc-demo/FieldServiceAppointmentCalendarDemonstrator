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

        public bool HasValidRange
        {
            get
            {
                return Duration.TotalSeconds > 0;
            }
        }

        internal bool Intersects(DateTimeSpan dateRange)
        {
            if (!HasValidRange || !dateRange.HasValidRange)
                throw new InvalidOperationException("Incomparable date ranges.");
            return end > dateRange.start || dateRange.end > start;
        }
    }
}