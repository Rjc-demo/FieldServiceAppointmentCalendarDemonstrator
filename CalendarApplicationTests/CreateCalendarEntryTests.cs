using FieldServiceAppointmentCalendar.Models;
using NUnit.Framework;
using System;
using System.Linq;

namespace CalendarApplicationTests
{
    public class CreateCalendarEntryTests
    {
        [Test]
        public void TestCanCreateAnAppointmentForAVehicle()
        {
            var appointment = new CalendarAppointment();

            var vehicle = new Vehicle();

            Assert.IsEmpty(vehicle.Appointments, "test pre-requisite");

            vehicle.Appointments.Add(appointment);

            Assert.AreEqual(appointment, vehicle.Appointments.Single());
        }
    }
}