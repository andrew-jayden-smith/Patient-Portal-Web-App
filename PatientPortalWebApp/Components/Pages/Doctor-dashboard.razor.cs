using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using PatientPortalWebApp.Data;
using PatientPortalWebApp.Models;
using System;
using System.Threading.Tasks;

namespace PatientPortalWebApp.Components.Pages
{
    public partial class Doctor_dashboard : ComponentBase
    {
        [Inject]
        private NavigationManager NavigationManager { get; set; }

        [Inject]
        private AppDbContext _dbContext { get; set; }

        [Parameter]
        public string DoctorId { get; set; }

        public Doctors Doctor { get; set; }

        [Parameter]
        public string PatientId { get; set; }

        public User Patient { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                if (!int.TryParse(DoctorId, out int doctorId))
                {
                    throw new InvalidOperationException("Invalid DoctorId format.");
                }

                Doctor = await _dbContext.Doctors.FindAsync(doctorId);

                if (Doctor == null)
                {
                    throw new InvalidOperationException("Doctor not found.");
                }
            }
            catch (InvalidOperationException)
            {
                // Handle case where admin is not found or invalid AdminId format
                NavigationManager.NavigateTo("/"); // Redirect to homepage or an error page
            }
        }
    }
}
