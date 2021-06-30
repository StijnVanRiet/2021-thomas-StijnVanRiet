using BarberApi.DTOs;
using BarberApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BarberApi.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentsController(IAppointmentRepository context)
        {
            _appointmentRepository = context;
        }

        // GET: api/Appointments
        /// <summary>
        /// Get all appointments
        /// </summary>
        /// <returns>array of appointments</returns>
        [HttpGet]
        public IEnumerable<Appointment> GetAppointments()
        {
            return _appointmentRepository.GetAll();
        }

        // GET: api/Appointments/5
        /// <summary>
        /// Get the appointment with given id
        /// </summary>
        /// <param name="id">the id of the appointment</param>
        /// <returns>The appointment</returns>
        [HttpGet("{id}")]
        public ActionResult<Appointment> GetAppointment(int id)
        {
            Appointment appointment = _appointmentRepository.GetBy(id);
            if (appointment == null) return NotFound();
            return appointment;
        }

        // POST: api/Appointments
        /// <summary>
        /// Adds a new appointment
        /// </summary>
        /// <param name="appointment">the new appointment</param>
        [HttpPost]
        public ActionResult<Appointment> PostAppointment(AppointmentDTO appointment)
        {
            Appointment appointmentToCreate = new Appointment()
            {
                FirstName = appointment.FirstName,
                LastName = appointment.LastName,
                PhoneNumber = appointment.PhoneNumber,
                Email = appointment.Email,
                Remarks = appointment.Remarks,
                Date = appointment.Date,
            };
            foreach (var i in appointment.Services)
                appointmentToCreate.AddService(new Service(i.Name, i.Price));
            _appointmentRepository.Add(appointmentToCreate);
            _appointmentRepository.SaveChanges();

            return CreatedAtAction(nameof(GetAppointment), new { id = appointmentToCreate.Id }, appointmentToCreate);
        }

        // DELETE: api/Appointments/5
        /// <summary>
        /// Deletes a appointment
        /// </summary>
        /// <param name="id">the id of the appointment to be deleted</param>

        [HttpDelete("{id}")]
        public IActionResult DeleteaAppointment(int id)
        {
            Appointment appointment = _appointmentRepository.GetBy(id);
            if (appointment == null)
            {
                return NotFound();
            }
            _appointmentRepository.Delete(appointment);
            _appointmentRepository.SaveChanges();
            return NoContent();
        }

    }
}
