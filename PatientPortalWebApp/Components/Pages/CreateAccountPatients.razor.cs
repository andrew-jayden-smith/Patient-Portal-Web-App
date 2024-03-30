using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using PatientPortalWebApp.Data;
using PatientPortalWebApp.Models;

namespace PatientPortalWebApp.Components.Pages
{
    public partial class CreateAccountPatients

    {
        [SupplyParameterFromForm]
        public User? _patient { get; set; }

        [Inject]
        public NavigationManager _navigationManager { get; set; }

        [Inject]
        private AppDbContext _dbContext { get; set; }

        protected override void OnInitialized() => _patient ??= new();

        private void Submit()
        {
            // write to database 
            _dbContext.Patients.Add(_patient);
            _dbContext.SaveChanges();
            _navigationManager.NavigateTo($"/");
        }
    }
}