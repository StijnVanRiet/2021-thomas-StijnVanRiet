using System.Collections.Generic;

namespace BarberApi.Models
{
    public interface IAppointmentRepository
    {
        Appointment GetBy(int id);
        bool TryGetAppointment(int id, out Appointment appointment);
        IEnumerable<Appointment> GetAll();
        IEnumerable<Appointment> GetBy(string firstName = null, string lastName = null);
        void Add(Appointment appointment);
        void Delete(Appointment appointment);
        void Update(Appointment appointment);
        void SaveChanges();
    }
}

