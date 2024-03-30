
﻿
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using PatientPortalWebApp.Data;
using PatientPortalWebApp.Models;

namespace PatientPortalWebApp.Components.Pages
{
    public partial class Patients
    {
        // inject dbcontext


        [Inject]
        // inject dbcontext 
        private AppDbContext _dbContext {  get; set; }

        private List<User> _patients;

        private String _PatientFirstName { get; set; }

        // this method happens everytime the page loads, i need to make a callback method that will happen when I click a submit button, I can call it on submit
        protected override Task OnInitializedAsync() 
        {
            // figure out how to use input boxes and input forms that add to data that links to the var _PatientFirstName

            // display element
        _patients = _dbContext.Patients.ToList();
            /*
            var testPatient = new Patient
            {
                FirstName = "Michael", 
                LastName = "Smith",
                Email = "Test",
                PhoneNumber = "Test"
            };
            _dbContext.Patients.Add(testPatient);
            _dbContext.SaveChanges();
            */
            
            _patients = _dbContext.Patients.ToList();

            return base.OnInitializedAsync();
        }

    }
}