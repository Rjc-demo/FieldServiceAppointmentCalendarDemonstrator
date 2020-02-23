using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FieldServiceAppointmentCalendar.Models
{
    public class IncompatibleAppointmentException : Exception
    {
        public IncompatibleAppointmentException(string message)
            : base(message)
        {

        }
    }
}
