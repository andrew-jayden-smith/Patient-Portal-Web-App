﻿using Microsoft.AspNetCore.Components;
using PatientPortalWebApp.Data;
using PatientPortalWebApp.Models;

namespace PatientPortalWebApp.Components.Pages
{
    public partial class AccountInfo
    {
        [Inject]
        private NavigationManager NavigationManager { get; set; }

        [Inject]
        private AppDbContext _dbContext { get; set; }

        [Parameter]
        public string PatientId { get; set; }

        public User Patient { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                if (!int.TryParse(PatientId, out int patientId))
                {
                    throw new InvalidOperationException("Invalid PatientId format.");
                }

                Patient = await _dbContext.Patients.FindAsync(patientId);
            }
            catch (InvalidOperationException)
            {
                // Handle case where patient is not found or invalid PatientId format
                NavigationManager.NavigateTo("/"); // Redirect to homepage or an error page
            }
        }
    }
}
