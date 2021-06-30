using Microsoft.EntityFrameworkCore;
using BarberApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace BarberApi.Data.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly BarberContext _context;
        private readonly DbSet<Appointment> _appointments;

        public AppointmentRepository(BarberContext dbContext)
        {
            _context = dbContext;
            _appointments = dbContext.Appointments;
        }

        public IEnumerable<Appointment> GetAll()
        {
            return _appointments.Include(r => r.Services).ToList();
        }

        public Appointment GetBy(int id)
        {
            return _appointments.Include(r => r.Services).SingleOrDefault(r => r.Id == id);
        }

        public bool TryGetAppointment(int id, out Appointment appointment)
        {
            appointment = _context.Appointments.Include(r => r.Services).FirstOrDefault(t => t.Id == id);
            return appointment != null;
        }

        public void Add(Appointment appointment)
        {
            _appointments.Add(appointment);
        }

        public void Update(Appointment appointment)
        {
            _context.Update(appointment);
        }

        public void Delete(Appointment appointment)
        {
            _appointments.Remove(appointment);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public IEnumerable<Appointment> GetBy(string firstName = null, string lastName = null)
        {
            var appointments = _appointments.AsQueryable();
            if (!string.IsNullOrEmpty(firstName))
                appointments = appointments.Where(r => r.FirstName.IndexOf(firstName) >= 0);
            if (!string.IsNullOrEmpty(lastName))
                appointments = appointments.Where(r => r.LastName.IndexOf(lastName) >= 0);
            return appointments.OrderBy(r => r.FirstName).ToList();
        }
    }
}
