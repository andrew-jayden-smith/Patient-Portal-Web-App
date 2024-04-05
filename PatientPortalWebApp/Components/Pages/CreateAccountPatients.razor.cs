using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using PatientPortalWebApp.Data;
using PatientPortalWebApp.Models;
using System.Data;

namespace PatientPortalWebApp.Components.Pages
{
    public partial class CreateAccountPatients

    {
        [SupplyParameterFromForm]
        public User? _patient { get; set; }

        [SupplyParameterFromForm]
        public Users? _user { get; set; }

        [Inject]
        public NavigationManager _navigationManager { get; set; }

        //[Inject]
        //private AppDbContext _dbContext { get; set; }

        [Inject]
        private MockData _dbContext { get; set; }

        protected override void OnInitialized() => _patient ??= new();

        private void Submit()
        {
            // write to database table patients
            _dbContext.Patients = _dbContext.Patients.Append(_patient);
            //_dbContext.SaveChanges();

            // write to database table users according to patients Id and Role
            var user = new Users
            {
                AffiliateId = _patient.Id,
                Role = "patient"
            };
            _dbContext.Users = _dbContext.Users.Append(user);
            //_dbContext.SaveChanges();

            // route back to login page
            _navigationManager.NavigateTo($"/");
        }
    }
}