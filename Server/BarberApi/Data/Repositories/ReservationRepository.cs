using Microsoft.EntityFrameworkCore;
using BarberApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace BarberApi.Data.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly ReservationContext _context;
        private readonly DbSet<Reservation> _reservations;

        public ReservationRepository(ReservationContext dbContext)
        {
            _context = dbContext;
            _reservations = dbContext.Reservations;
        }

        public IEnumerable<Reservation> GetAll()
        {
            return _reservations.Include(r => r.Services).ToList();
        }

        public Reservation GetBy(int id)
        {
            return _reservations.Include(r => r.Services).SingleOrDefault(r => r.Id == id);
        }

        public bool TryGetReservation(int id, out Reservation reservation)
        {
            reservation = _context.Reservations.Include(r => r.Services).FirstOrDefault(t => t.Id == id);
            return reservation != null;
        }

        public void Add(Reservation reservation)
        {
            _reservations.Add(reservation);
        }

        public void Update(Reservation reservation)
        {
            _context.Update(reservation);
        }

        public void Delete(Reservation reservation)
        {
            _reservations.Remove(reservation);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public IEnumerable<Reservation> GetBy(string firstName = null, string lastName = null)
        {
            var reservations = _reservations.AsQueryable();
            if (!string.IsNullOrEmpty(firstName))
                reservations = reservations.Where(r => r.FirstName.IndexOf(firstName) >= 0);
            if (!string.IsNullOrEmpty(lastName))
                reservations = reservations.Where(r => r.LastName.IndexOf(lastName) >= 0);
            return reservations.OrderBy(r => r.FirstName).ToList();
        }
    }
}
