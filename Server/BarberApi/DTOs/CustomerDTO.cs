using BarberApi.Models;
using System.Collections.Generic;

namespace BarberApi.DTOs
{
    public class CustomerDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public IEnumerable<Appointment> Appointments { get; set; }

        public CustomerDTO() { }

        public CustomerDTO(Customer customer) : this()
        {
            FirstName = customer.FirstName;
            LastName = customer.LastName;
            Email = customer.Email;
            Appointments = (IEnumerable<Appointment>)customer.OwnAppointments;
        }
    }
}
