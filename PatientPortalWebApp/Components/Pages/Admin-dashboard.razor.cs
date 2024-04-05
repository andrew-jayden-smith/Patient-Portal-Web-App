using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using PatientPortalWebApp.Data;
using PatientPortalWebApp.Models;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;

namespace PatientPortalWebApp.Components.Pages
{
    public partial class Admin_dashboard : ComponentBase
    {
        [Inject]
        private NavigationManager NavigationManager { get; set; }

        //[Inject]
        //private AppDbContext _dbContext { get; set; }

        [Inject]
        private MockData _dbContext { get; set; }

        [Parameter]
        public string AdminId { get; set; }

        public Admin Admin { get; set; }

        private List<User> _patients;


        private List<Doctors> _doctors;

        // This method happens every time the page loads
        protected override async Task OnInitializedAsync()
        {
            try
            {
                if (!int.TryParse(AdminId, out int adminId))
                {
                    throw new InvalidOperationException("Invalid AdminId format.");
                }

                Admin = _dbContext.Admins.Where(x => x.Id == adminId).FirstOrDefault();

                if (Admin == null)
                {
                    throw new InvalidOperationException("Admin not found.");
                }
            }
            catch (InvalidOperationException)
            {
                // Handle case where admin is not found or invalid AdminId format
                NavigationManager.NavigateTo("/"); // Redirect to homepage or an error page
            }

            // Retrieve patients from the database
            _patients = _dbContext.Patients.ToList();
            if (_patients == null)
            {
                // Handle case where patients list is null
                // For example, display a message or log an error
                _patients = new List<User>(); // Initialize to an empty list to avoid null reference exceptions
            }

            // Retrieve doctors from the database
            _doctors = _dbContext.Doctors.ToList();
            if (_doctors == null)
            {
                // Handle case where doctors list is null
                // For example, display a message or log an error
                _doctors = new List<Doctors>(); // Initialize to an empty list to avoid null reference exceptions
            }
        }

    }
}
