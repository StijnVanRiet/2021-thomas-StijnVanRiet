namespace BarberApi.Models
{
    public class CustomerAppointment
    {
        #region Properties
        public int CustomerId { get; set; }

        public int AppointmentId { get; set; }

        public Customer Customer { get; set; }

        public Appointment Appointment { get; set; }
        #endregion
    }
}
