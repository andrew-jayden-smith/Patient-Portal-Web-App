
namespace PatientPortalWebApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public DateOnly DateOfBirth { get; set; }

        public string Address { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
            
        public string Prescription { get; set; }

    }
}
