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

        //[Inject]
        //private MockData _dbContext { get; set; }

        [Parameter]
        public string AdminId { get; set; }

        public Admin Admin { get; set; }

        public string BookingId {  get; set; }

        private List<User> _patients;

        private List<Doctors> _doctors;

        private List<Booking> _bookings;

        //private async Task ChangeStatus(int bookingId, string status)
        //{
        //    var booking = _bookings.FirstOrDefault(b => b.BookingId == bookingId);
        //    if (booking != null)
        //    {
        //        booking.Status = status;
        //        StateHasChanged(); // Re-render the UI to reflect the status change
        //    }
        //}

        //private async Task ApproveAppointment(int bookingId)
        //{
        //    var booking = _bookings.FirstOrDefault(b => b.BookingId == bookingId);
        //    if (booking != null)
        //    {
        //        booking.Status = "Approved";
        //        await _dbContext.SaveChangesAsync(); // Save changes to the database
        //    }
        //}

        //private async Task CancelAppointment(int bookingId)
        //{
        //    var booking = _bookings.FirstOrDefault(b => b.BookingId == bookingId);
        //    if (booking != null)
        //    {
        //        booking.Status = "Cancelled";
        //        await _dbContext.SaveChangesAsync(); // Save changes to the database
        //    }
        //}
        private async Task Submit(int bookingId)
        {
            var booking = _bookings.FirstOrDefault(b => b.BookingId == bookingId);
            if (booking != null)
            {
                // No need to change the status here, as it's already updated by the InputText element
                await _dbContext.SaveChangesAsync(); // Save changes to the database

                // Reload bookings from the database to ensure the UI reflects the latest changes
                _bookings = await _dbContext.Bookings.ToListAsync();
            }
        }



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

            _bookings = _dbContext.Bookings.ToList();
            if (_bookings == null)
            {
                // Handle case where patients list is null
                // For example, display a message or log an error
                _bookings = new List<Booking>(); // Initialize to an empty list to avoid null reference exceptions
            }
        }

    }
}
