using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using PatientPortalWebApp.Data;
using PatientPortalWebApp.Models;
using System.Linq;

namespace PatientPortalWebApp.Components.Pages
{
    public partial class Login
    {
        [SupplyParameterFromForm]
        public Patient _patient { get; set; } = new Patient();

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        private AppDbContext DbContext { get; set; }

        protected override void OnInitialized() { }

        private bool loginSuccess = true;

        private void Submit()
        {
            // Check if the provided email and password match any existing user
            var existingPatient = DbContext.Patients.FirstOrDefault(p => p.Email == _patient.Email && p.Password == _patient.Password);

            if (existingPatient != null)
            {
                // Successful login
                // Redirect to the appropriate page, for example:
                loginSuccess = true;
                NavigationManager.NavigateTo($"/patient-dashboard");
            }
            else
            {
                // Failed login
                // You can display an error message here if needed
                loginSuccess = false;
                StateHasChanged();

            }
        }
    }
}

