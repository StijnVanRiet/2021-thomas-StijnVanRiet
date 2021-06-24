using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BarberApi.Models
{
    public class Reservation
    {
        #region Properties
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        public string Remarks { get; set; }
        public string Barber { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public ICollection<Service> Services { get; set; }
        #endregion

        #region Constructors
        public Reservation()
        {
            Services = new List<Service>();
        }

        public Reservation(
            string firstName,
            string lastName,
            string phoneNumber,
            string email,
            DateTime date,
            ICollection<Service> services
            ) : this()
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            Date = date;
            Services = services;
        }
        #endregion

        #region Methods
        public void AddService(Service service) => Services.Add(service);
        #endregion
    }
}