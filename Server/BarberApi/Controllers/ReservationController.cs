using Microsoft.AspNetCore.Mvc;
using BarberApi.DTOs;
using BarberApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace BarberApi.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationController(IReservationRepository context)
        {
            _reservationRepository = context;
        }

        // GET: api/Reservations
        /// <summary>
        /// Get all reservations
        /// </summary>
        /// <returns>array of reservations</returns>
        [HttpGet]
        public IEnumerable<Reservation> GetReservations()
        {
            return _reservationRepository.GetAll();
        }

        // GET: api/Reservations/5
        /// <summary>
        /// Get the reservation with given id
        /// </summary>
        /// <param name="id">the id of the reservation</param>
        /// <returns>The reservation</returns>
        [HttpGet("{id}")]
        public ActionResult<Reservation> GetReservation(int id)
        {
            Reservation reservation = _reservationRepository.GetBy(id);
            if (reservation == null) return NotFound();
            return reservation;
        }

        // POST: api/Reservations
        /// <summary>
        /// Adds a new reservation
        /// </summary>
        /// <param name="reservation">the new reservation</param>
        [HttpPost]
        public ActionResult<Reservation> PostReservation(ReservationDTO reservation)
        {
            Reservation reservationToCreate = new Reservation() { 
                FirstName = reservation.FirstName,
                LastName = reservation.LastName,
                PhoneNumber = reservation.PhoneNumber,
                Email = reservation.Email,
                Barber = reservation.Barber,
                Remarks = reservation.Remarks,
                Date = reservation.Date,
            };
            foreach (var i in reservation.Services)
                reservationToCreate.AddService(new Service(i.Name, i.Price));
            _reservationRepository.Add(reservationToCreate);
            _reservationRepository.SaveChanges();

            return CreatedAtAction(nameof(GetReservation), new { id = reservationToCreate.Id }, reservationToCreate);
        }

        // PUT: api/Reservations/5
        /// <summary>
        /// Modifies a reservation
        /// </summary>
        /// <param name="id">id of the reservation to be modified</param>
        /// <param name="reservation">the modified reservation</param>
        [HttpPut("{id}")]
        public IActionResult PutReservation(int id, Reservation reservation)
        {
            if (id != reservation.Id)
            {
                return BadRequest();
            }
            _reservationRepository.Update(reservation);
            _reservationRepository.SaveChanges();
            return NoContent();
        }

        // DELETE: api/Reservations/5
        /// <summary>
        /// Deletes a reservation
        /// </summary>
        /// <param name="id">the id of the reservation to be deleted</param>

        [HttpDelete("{id}")]
        public IActionResult DeleteReservation(int id)
        {
            Reservation reservation = _reservationRepository.GetBy(id);
            if (reservation == null)
            {
                return NotFound();
            }
            _reservationRepository.Delete(reservation);
            _reservationRepository.SaveChanges();
            return NoContent();
        }

    }
}
