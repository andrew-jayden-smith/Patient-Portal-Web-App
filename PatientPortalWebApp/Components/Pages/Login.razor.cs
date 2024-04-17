using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using PatientPortalWebApp.Data;
using PatientPortalWebApp.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PatientPortalWebApp.Components.Pages
{
    public partial class Login
    {
        [SupplyParameterFromForm]
        public User _user { get; set; } = new User();

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        private AppDbContext dbContext { get; set; }

        //[Inject]
        //private MockData dbContext { get; set; }

        protected override void OnInitialized() { }

        private bool loginSuccess = true;

        private void Submit()
        {
            var users = dbContext.Users;

            var patients = dbContext.Patients.ToList();
            var doctors = dbContext.Doctors.ToList();
            var admins = dbContext.Admins.ToList();

            // create a list of loginUsers
            List<LoginUser?> loginUsers = new List<LoginUser?>();
            // loop the users to see what their role 
            foreach (var user in users)
            {
                if (user.Role == "patient") 
                {
                    loginUsers.Add(new LoginUser
                    {
                        User = user,
                        Email = patients.FirstOrDefault(p => p.Id == user.AffiliateId).Email,
                        Password = patients.FirstOrDefault(p => p.Id == user.AffiliateId).Password,

                    });
                } 
                else if (user.Role == "admin")
                {
                    loginUsers.Add(new LoginUser
                    {
                        User = user,
                        Email = admins.FirstOrDefault(p => p.Id == user.AffiliateId).Email,
                        Password = admins.FirstOrDefault(p => p.Id == user.AffiliateId).Password,

                    });
                }
                else if (user.Role == "doctor")
                {
                    loginUsers.Add(new LoginUser
                    {
                        User = user,
                        Email = doctors.FirstOrDefault(p => p.Id == user.AffiliateId).Email,
                        Password = doctors.FirstOrDefault(p => p.Id == user.AffiliateId).Password,

                    });
                }
            }


            // Check if the provided email and password match any existing user
            var existingUser = loginUsers
                .Where(p => p.HasValue)
                .FirstOrDefault(p => p.Value.Email == _user.Email && p.Value.Password == _user.Password);

            if (existingUser != null)
            {
                // Successful login
                // Redirect to the appropriate page, for example:
                loginSuccess = true;

                if (existingUser.Value.User.Role == "patient")
                {
                    NavigationManager.NavigateTo($"/patient-dashboard/{existingUser.Value.User.AffiliateId}");
                }
                else if (existingUser.Value.User.Role == "admin")
                {
                    NavigationManager.NavigateTo($"/admin-dashboard/{existingUser.Value.User.AffiliateId}");
                }
                else if (existingUser.Value.User.Role == "doctor")
                {
                    NavigationManager.NavigateTo($"/doctor-dashboard/{existingUser.Value.User.AffiliateId}");
                }
                
            }
            else
            {
                // Failed login
                // You can display an error message here if needed
                loginSuccess = false;
                StateHasChanged();

            }
        }

        public struct LoginUser
        {
            public Users User { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }

        }
    }
}

