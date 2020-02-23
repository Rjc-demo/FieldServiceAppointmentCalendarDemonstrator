using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace FieldServiceAppointmentCalendar.Models
{
    public class Calendar : IEnumerable<CalendarAppointment>
    {
        private List<CalendarAppointment> _appointments = new List<CalendarAppointment>();

        public void Add(CalendarAppointment appointment)
        {
            _appointments.Add(appointment);
        }

        public IEnumerator<CalendarAppointment> GetEnumerator()
        {
            return _appointments.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
