using System;
using System.ComponentModel.DataAnnotations;

namespace FieldServiceAppointmentCalendar.Models
{
    public class Vehicle
    {
        public Vehicle(string registration)
            : this()
        {
            Registration = registration;
        }

        public Vehicle()
        {
            Appointments = new Calendar();
        }

        [UIHint("calendar")]
        public Calendar Appointments { get; set; }

        [StringLength(16)]
        [Display(Name = "Vehicle Registration")]
        public string Registration { get; set; }

        [Key]
        public Guid ID { get; set; }
    }
}