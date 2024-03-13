using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using PatientPortalWebApp.Data;
using PatientPortalWebApp.Models;
using System;
using System.Linq;

namespace PatientPortalWebApp.Components.Pages
{
    public partial class Login
    {
        [Inject]
        public NavigationManager _navigationManager { get; set; }

        [Inject]
        private AppDbContext DbContext { get; set; }

        private string Email { get; set; }
        private string Password { get; set; }
        private string ErrorMessage { get; set; }

        private async void Submit()
        {
            try
            {
                var patient = await DbContext.Patients.FirstOrDefaultAsync(p => p.Email == Email && p.Password == Password);
                if (patient != null)
                {
                    Console.WriteLine();
                    // Login successful
                    _navigationManager.NavigateTo("/home-page");
                }
                else
                {
                    ErrorMessage = "Invalid email or password. Please try again.";
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = "An error occurred: " + ex.Message;
            }
        }
    }
}
