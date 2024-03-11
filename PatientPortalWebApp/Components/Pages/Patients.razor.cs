<<<<<<< HEAD
﻿
using Microsoft.AspNetCore.Components;
=======
﻿using Microsoft.AspNetCore.Components;
>>>>>>> 9450603759ee061349a0cb679b078cb5632e285f
using Microsoft.EntityFrameworkCore;
using PatientPortalWebApp.Data;
using PatientPortalWebApp.Models;

namespace PatientPortalWebApp.Components.Pages
{
    public partial class Patients
    {
<<<<<<< HEAD
        // inject dbcontext
        [Inject] 
=======
        [Inject]
        // inject dbcontext 
>>>>>>> 9450603759ee061349a0cb679b078cb5632e285f
        private AppDbContext _dbContext {  get; set; }

        private List<Patient> _patients;

<<<<<<< HEAD
        //private String _PatientFirstName { get; set; }
=======
        private String _PatientFirstName { get; set; }
>>>>>>> 9450603759ee061349a0cb679b078cb5632e285f

        // this method happens everytime the page loads, i need to make a callback method that will happen when I click a submit button, I can call it on submit
        protected override Task OnInitializedAsync() 
        {
            // figure out how to use input boxes and input forms that add to data that links to the var _PatientFirstName

            // display element
<<<<<<< HEAD
        _patients = _dbContext.Patients.ToList();
=======
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

>>>>>>> 9450603759ee061349a0cb679b078cb5632e285f

            return base.OnInitializedAsync();
        }

    }
}
<<<<<<< HEAD

=======
>>>>>>> 9450603759ee061349a0cb679b078cb5632e285f
