using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FieldServiceAppointmentCalendar.Models;
using System.ComponentModel.DataAnnotations;

namespace FieldServiceAppointmentCalendar.Models
{
    public class Fleet : DbContext
    {
        public Fleet(DbContextOptions<Fleet> context)
            : base(context)
        {

        }
        
        public DbSet<Vehicle> Vehicles
        {
            get;
            set;
        }

        public IEnumerable<CalendarAppointment> FleetCalendar 
        {
            get
            {
                return new CompositeCalendar(Vehicles.Select(vehicle => vehicle.Appointments));
            }
        }
    }
}
