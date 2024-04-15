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

        //[Inject]
        //private MockData _dbContext { get; set; }

        [Parameter]
        public string DoctorId { get; set; }

        public Doctors Doctor { get; set; }

        [Parameter]
        public string PatientId { get; set; }

        public User Patient { get; set; }

        private List<User> _patients;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                if (!int.TryParse(DoctorId, out int doctorId))
                {
                    throw new InvalidOperationException("Invalid DoctorId format.");
                }

                Doctor =  _dbContext.Doctors.Where(x => x.Id == doctorId).FirstOrDefault();

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
            _patients = _dbContext.Patients.ToList();
            if (_patients == null)
            {
                // Handle case where patients list is null
                // For example, display a message or log an error
                _patients = new List<User>(); // Initialize to an empty list to avoid null reference exceptions
            }
        }
    }
}
