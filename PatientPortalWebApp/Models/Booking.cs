namespace PatientPortalWebApp.Models
{
    public class Booking
    {
        public int BookingId { get; set; }

        public int AppointmentTime { get; set; }

        public string DoctorName { get; set; }

        public string PatientName { get; set; }

        public string Description { get; set; }
    }
}
