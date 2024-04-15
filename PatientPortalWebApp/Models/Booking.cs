namespace PatientPortalWebApp.Models
{
    public class Booking
    {
        public int BookingId { get; set; }

        public DateOnly AppointmentDate { get; set; }

        public TimeOnly AppointmentTime { get; set; }

        public int DoctorId { get; set; }

        public int PatientId { get; set; }

        public string? Description { get; set; }

        public string Status { get; set; }

    }
}
