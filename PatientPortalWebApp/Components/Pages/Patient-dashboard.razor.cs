using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using PatientPortalWebApp.Data;
using PatientPortalWebApp.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace PatientPortalWebApp.Components.Pages
{
    public partial class Patient_dashboard : ComponentBase
    {
        [Inject]
        private NavigationManager NavigationManager { get; set; }

        [Inject]
        private AppDbContext _dbContext { get; set; }

        [SupplyParameterFromForm]
        public Booking? NewBooking { get; set; } = new Booking();

        private List<Doctors> _doctors;

        [Parameter]
        public string PatientId { get; set; }

        public User Patient { get; set; }

        // Property to bind appointment time input field
        public string AppointmentTimeString { get; set; }

        [SupplyParameterFromForm]
        public int Hour { get; set; }

        [SupplyParameterFromForm]
        public int Minute { get; set; }

        private async Task RequestAppointment()
        {
 

            NewBooking.AppointmentTime = new TimeOnly(Hour, Minute);


            NewBooking.PatientId = Patient.Id;
                _dbContext.Bookings.Add(NewBooking);
                _dbContext.SaveChanges();

        }

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