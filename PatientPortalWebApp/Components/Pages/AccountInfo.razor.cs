using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using PatientPortalWebApp.Data;
using PatientPortalWebApp.Models;
using System;

namespace PatientPortalWebApp.Components.Pages
{
    public partial class AccountInfo
    {
        [SupplyParameterFromForm]
        public User _user { get; set; } = new User();

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        [Inject]
        private AppDbContext _dbContext { get; set; }

        [Parameter]
        public string PatientId { get; set; }

        public User Patient { get; set; }
        protected override async Task OnInitializedAsync(){}

        private async Task UpdateAccount()
        {
            var users = _dbContext.Users;

            var patients = _dbContext.Patients.ToList();


            try
            {
                var response = await HttpClient.PutAsJsonAsync($"api/patients/{PatientId}", Patient);
                if (response.IsSuccessStatusCode)
                {
                    // Handle successful update
                }
                else
                {
                    // Handle failure
                }
            }
            catch (Exception ex)
            {
                // Handle exception
            }
        }
    }
}
