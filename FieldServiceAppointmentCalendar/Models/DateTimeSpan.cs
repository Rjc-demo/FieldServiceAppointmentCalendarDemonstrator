using System;

namespace FieldServiceAppointmentCalendar.Models
{
    public class DateTimeSpan
    {
        public DateTimeSpan(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }

        public TimeSpan Duration
        {
            get
            {
                return End - Start;
            }
        }

        public bool HasValidRange
        {
            get
            {
                return Duration.TotalSeconds > 0;
            }
        }

        public DateTime Start { get; private set; }

        public DateTime End { get; private set; }

        internal bool Intersects(DateTimeSpan dateRange)
        {
            if (!HasValidRange || !dateRange.HasValidRange)
                throw new InvalidOperationException("Incomparable date ranges.");
            return End > dateRange.Start && dateRange.End > Start;
        }
    }
}