using System.Collections.Generic;
using PatientPortalWebApp.Models;

namespace PatientPortalWebApp.Data
{
    public class MockData
    {
        // Lists to store mock data
        public List<User> Patients { get; set; }
        public List<Doctors> Doctors { get; set; }
        public List<Booking> Bookings { get; set; }
        public List<MedicalRecords> MedicalRecords { get; set; }
        public List<Admin> Admins { get; set; }
        public List<Users> Users { get; set; }

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

        // Add methods to mimic CRUD operations

        // Example: Add a patient
        public void AddPatient(User patient)
        {
            Patients.Add(patient);
        }

        // Example: Retrieve all patients
        public List<User> GetAllPatients()
        {
            return Patients;
        }

        // Add more methods as needed for CRUD operations
    }
}
