﻿using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using PatientPortalWebApp.Data;
using PatientPortalWebApp.Models;
using System;
using System.Threading.Tasks;
using static PatientPortalWebApp.Components.Pages.Login;

namespace PatientPortalWebApp.Components.Pages
{
    public partial class Patient_dashboard : ComponentBase
    {
        [Inject]
        private NavigationManager NavigationManager { get; set; }

        //[Inject]
        //private AppDbContext _dbContext { get; set; }

        [Inject]
        private MockData _dbContext { get; set; }

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

                Patient = _dbContext.Patients.Where(x => x.Id == patientId).FirstOrDefault();
            }
           catch (InvalidOperationException)
            {
                // Handle case where patient is not found or invalid PatientId format
                NavigationManager.NavigateTo("/"); // Redirect to homepage or an error page
            }
        }
    }
}
