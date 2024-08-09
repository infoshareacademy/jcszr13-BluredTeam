using PP0.EntityFrameworkCore.Database.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace PP0.WEB.ViewModels
{
    public class RegisterVM
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords don't match.")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }

        [DataType(DataType.MultilineText)]
        public string? Address { get; set; }

        //public RoleType UserRole { get; set; } = RoleType.Patient;
        public bool IsPatient { get; set; }
        public bool IsDoctor { get; set; }
        public List<string> UserRoles { get; set; } = new List<string>() { RoleType.Patient.ToString() };

        public void UpdateUserRoles()
        {
            UserRoles.Clear(); 

            if (IsDoctor)
            {
                UserRoles.Add("Doctor");
            }
            if (IsPatient)
            {
                UserRoles.Add("Patient");
            }
           
        }
    }
}
