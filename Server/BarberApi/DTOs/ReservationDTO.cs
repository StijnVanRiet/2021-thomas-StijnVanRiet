using BarberApi.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BarberApi.DTOs
{
    public class ReservationDTO
    {
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
        public System.DateTime Date { get; set; }
        [Required]
        public IList<Service> Services { get; set; }
    }
}
