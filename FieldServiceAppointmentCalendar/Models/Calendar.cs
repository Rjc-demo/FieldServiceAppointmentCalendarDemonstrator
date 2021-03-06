﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FieldServiceAppointmentCalendar.Models
{
    public class Calendar : IEnumerable<CalendarAppointment>
    {
        private List<CalendarAppointment> _appointments = new List<CalendarAppointment>();

        public void Add(CalendarAppointment appointment)
        {
            foreach (var existingAppointment in _appointments)
                if (appointment.IsIncompatibleWith(existingAppointment))
                    throw new IncompatibleAppointmentException("Overlap with existing appointment.");
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

        [Key]
        public Guid ID { get; set; }
    }
}
