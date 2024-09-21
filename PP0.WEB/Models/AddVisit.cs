using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PP0.EntityFrameworkCore.Database.Entities.Enums;
using PP0.WEB.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace PP0.WEB.Models
{
    public class AddVisit
    {
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public VisitType Type { get; set; }
        public string DoctorId { get; set; }
        public string PatientId { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Recomendations { get; set; }

        [Required]
        public string Referrals { get; set; }

        [Required]
        public string Prescriptions { get; set; }

        public List<SelectListItem> Doctors { get; set; }
        
        public List<SelectListItem> Patients { get; set; }
    }
}

