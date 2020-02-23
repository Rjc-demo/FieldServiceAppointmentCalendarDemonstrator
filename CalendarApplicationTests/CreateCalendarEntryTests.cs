using FieldServiceAppointmentCalendar.Models;
using NUnit.Framework;
using System;
using System.Linq;

namespace CalendarApplicationTests
{
    public class CreateCalendarEntryTests
    {
        private CalendarAppointment _validAppointment;

        [SetUp]
        public void Setup()
        {
            _validAppointment = new CalendarAppointment("valid summary");
        }

        [Test]
        public void TestCanCreateAnAppointmentForAVehicle()
        {
            var appointment = _validAppointment;

            var vehicle = new Vehicle();

            Assert.IsEmpty(vehicle.Appointments, "test pre-requisite");

            vehicle.Appointments.Add(appointment);

            Assert.AreEqual(appointment, vehicle.Appointments.Single());
        }

        /// <summary>
        /// requirement 3.1.5
        /// </summary>
        /// <param name="badSummary"></param>
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void TestThatAppointmentSummaryIsRequired(string badSummary)
        {
            Assert.Throws<ArgumentException>(() => new CalendarAppointment(badSummary));
        }
    }
}