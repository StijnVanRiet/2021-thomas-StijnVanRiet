using BarberApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BarberApi.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class DatesController : ControllerBase
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public DatesController(IAppointmentRepository context)
        {
            _appointmentRepository = context;
        }

        // GET: api/Dates
        /// <summary>
        /// Get all not available dates 
        /// </summary>
        /// <returns>array of dates </returns>
        [HttpGet]
        public IEnumerable<DateTime> GetNotAvailableDates()
        {
            // make list of all taken dates+time
            List<DateTime> dates = new List<DateTime>();
            _appointmentRepository.GetAll().ToList().ForEach(x => dates.Add(x.Date));

            // remove duplicates
            dates = dates.Distinct().ToList();

            // remove timecomponent
            List<DateTime> datesNoTime = new List<DateTime>();
            dates.ForEach(x => datesNoTime.Add(x.Date));

            // count dates
            var counts = datesNoTime.GroupBy(i => i);

            // if date occurs 13 times => date is full
            List<DateTime> notAvailableDates = new List<DateTime>();
            foreach (var grp in counts)
            {
                if (grp.Count() >= 13)
                {
                    notAvailableDates.Add(grp.Key);
                }
            }

            return notAvailableDates;
        }

        // GET: api/Dates/2021-08-09T14:33:24.045Z
        /// <summary>
        /// Get the time slots of given date
        /// </summary>
        /// <param name="date">the date of the time slots</param>
        /// <returns>The time slots</returns>
        [HttpGet("{date}")]
        public IEnumerable<string> GetAvailableTimeSlots(DateTime date)
        {
            DateTime d = date.Date;
            List<Appointment> b = (List<Appointment>)_appointmentRepository.GetAll().Where(x => x.Date.Date == date.Date).ToList();
            List<DateTime> a = new List<DateTime>();
            b.ForEach(x => a.Add(x.Date));
            List<String> availableTimeSlots = new List<String>();
            availableTimeSlots.Add("08:00");
            availableTimeSlots.Add("08:45");
            availableTimeSlots.Add("09:30");
            availableTimeSlots.Add("10:15");
            availableTimeSlots.Add("11:00");
            availableTimeSlots.Add("11:45");
            availableTimeSlots.Add("13:00");
            availableTimeSlots.Add("13:45");
            availableTimeSlots.Add("14:30");
            availableTimeSlots.Add("15:15");
            availableTimeSlots.Add("16:00");
            availableTimeSlots.Add("16:45");
            availableTimeSlots.Add("17:30");
            List<String> takenTimeSlots = new List<String>();
            a.ForEach(x => takenTimeSlots.Add(x.ToString("HH:mm")));
            takenTimeSlots.ForEach(x => availableTimeSlots.Remove(x));
            return availableTimeSlots;
        }
    }
}