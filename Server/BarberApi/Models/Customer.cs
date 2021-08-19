using System.Collections.Generic;
using System.Linq;

namespace BarberApi.Models
{
    public class Customer
    {
        #region Properties
        //add extra properties if needed
        public int CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public ICollection<CustomerAppointment> Appointments { get; private set; }

        public IEnumerable<Appointment> OwnAppointments => Appointments.Select(f => f.Appointment);
        #endregion

        #region Constructors
        public Customer()
        {
            Appointments = new List<CustomerAppointment>();
        }
        #endregion

        #region Methods
        public void AddAppointment(Appointment appointment)
        {
            Appointments.Add(new CustomerAppointment() { AppointmentId = appointment.Id, CustomerId = CustomerId, Appointment = appointment, Customer = this });
        }
        #endregion
    }
}

