using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PatientPortalWebApp.Models;

namespace PatientPortalWebApp.Data
{
    public class MockData
    {
        // Lists to store mock data
        public IEnumerable<User> Patients { get; set; }
        public IEnumerable<Doctors> Doctors { get; set; }

        public IEnumerable<Booking> Bookings { get; set; }

        public IEnumerable<MedicalRecords> MedicalRecords { get; set; }

        public IEnumerable<Admin> Admins { get; set; }

        public IEnumerable<Users> Users { get; set; }

        public MockData()
        {
            // Initialize lists
            Patients = new List<User>();
            Doctors = new List<Doctors>();
            Bookings = new List<Booking>();
            MedicalRecords = new List<MedicalRecords>();
            Admins = new List<Admin>();
            Users = new List<Users>();
        }
    }
}
