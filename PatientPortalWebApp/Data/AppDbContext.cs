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
    }
}
