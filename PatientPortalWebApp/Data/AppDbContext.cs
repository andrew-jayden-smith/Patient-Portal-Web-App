using PatientPortalWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace PatientPortalWebApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { 

        }
        // Creating new tables
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctors> Doctors { get; set; }

        public DbSet<Booking> Bookings { get; set; }

        public DbSet<MedicalRecords> MedicalRecords { get; set; }

        public DbSet<Admin> Admins { get; set; }

        public DbSet<Users> Users { get; set; }




    }
}
