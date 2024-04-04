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

        [Inject]
        private AppDbContext _dbContext { get; set; }

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

                Admin = await _dbContext.Admins.FindAsync(adminId);

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

            // Retrieve patients and doctors from the database
            _patients = await _dbContext.Patients.ToListAsync();
            _doctors = await _dbContext.Doctors.ToListAsync();
        }
    }
}
