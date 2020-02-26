using FieldServiceAppointmentCalendar.Models;
using NUnit.Framework;
using System;
using System.Linq;

namespace CalendarApplicationTests
{
    public class CreateCalendarEntryTests
    {
        private const string validSummary = "valid summary";
        private const string validLocation = "valid Location";
        private const string validRegistration = "LL00LLL";
        private CalendarAppointment _validAppointment;
        private DateTimeSpan _validDateRange;

        [SetUp]
        public void Setup()
        {
            _validDateRange = new DateTimeSpan(DateTime.Now, DateTime.Now.AddDays(1));
            _validAppointment = new CalendarAppointment(validSummary, validLocation, _validDateRange);
        }

        [Test]
        public void TestCanCreateAnAppointmentForAVehicle()
        {
            var appointment = _validAppointment;

            var vehicle = new Vehicle(validRegistration);

            Assert.IsEmpty(vehicle.Appointments, "test pre-requisite");

            vehicle.Appointments.Add(appointment);

            Assert.AreEqual(appointment, vehicle.Appointments.Single());
        }

        /// <summary>
        /// requirement 3.1.5
        /// </summary>
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void TestThatAppointmentSummaryIsRequired(string badSummary)
        {
            Assert.Throws<ArgumentException>(() => new CalendarAppointment(badSummary, validLocation, _validDateRange));
        }

        /// <summary>
        /// requirement 3.1.5
        /// </summary>
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void TestThatAppointmentLocationIsRequired(string badLocation)
        {
            Assert.Throws<ArgumentException>(() => new CalendarAppointment(validSummary, badLocation, _validDateRange));
        }

        [Test]
        public void TestThatANegativeDateRangeIsRejected()
        {
            var badDateRange = new DateTimeSpan(DateTime.Now, DateTime.Now.AddDays(-1));
            Assert.Throws<ArgumentException>(() => new CalendarAppointment(validSummary, validLocation, badDateRange));
        }

        [Test]
        public void TestThatAVehicleCannotHaveOverlappingAppointments()
        {
            var appointment = _validAppointment;
            var vehicle = new Vehicle(validRegistration);

            vehicle.Appointments.Add(appointment);

            Assert.Throws<IncompatibleAppointmentException>(() => vehicle.Appointments.Add(appointment));
        }

        [Test]
        public void TestCanAddAConsecutiveAppointment()
        {
            var appointment = _validAppointment;
            var vehicle = new Vehicle(validRegistration);
            vehicle.Appointments.Add(appointment);
            var previousAppointmentEnd = appointment.DateRange.End;
            var secondAppointment = new CalendarAppointment(validSummary, validLocation, new DateTimeSpan(previousAppointmentEnd, previousAppointmentEnd.AddDays(1)));
            
            vehicle.Appointments.Add(secondAppointment);

            Assert.AreEqual(2, vehicle.Appointments.Count());
        }

        [Test]
        public void TestCanInsertAPreviousAppointment()
        {
            var appointment = _validAppointment;
            var vehicle = new Vehicle(validRegistration);
            vehicle.Appointments.Add(appointment);
            var previousAppointmentEnd = appointment.DateRange.Start.AddDays(-1);
            var secondAppointment = new CalendarAppointment(validSummary, validLocation, new DateTimeSpan(previousAppointmentEnd, previousAppointmentEnd.AddDays(1)));

            vehicle.Appointments.Add(secondAppointment);

            Assert.AreEqual(2, vehicle.Appointments.Count());
        }
    }
}