using System.Collections.Generic;

namespace BarberApi.Models
{
    public interface IAppointmentRepository
    {
        Appointment GetBy(int id);
        bool TryGetAppointment(int id, out Appointment appointment);
        IEnumerable<Appointment> GetAll();
        void Add(Appointment appointment);
        void Delete(Appointment appointment);
        void Update(Appointment appointment);
        void SaveChanges();
    }
}

