using System.Collections.Generic;

namespace BarberApi.Models
{
    public interface IReservationRepository
    {
        Reservation GetBy(int id);
        bool TryGetReservation(int id, out Reservation reservation);
        IEnumerable<Reservation> GetAll();
        IEnumerable<Reservation> GetBy(string firstName = null, string lastName = null);
        void Add(Reservation reservation);
        void Delete(Reservation reservation);
        void Update(Reservation reservation);
        void SaveChanges();
    }
}

