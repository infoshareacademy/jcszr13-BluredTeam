using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP0.EntityFrameworkCore.Database.Entities
{
    public class User : IdentityUser
    {
        [StringLength(100)]
        [MaxLength(100)]
        
        public string? Name { get; set; } = null;
        public string? Address { get; set; }
        public string? Specialization { get; set; }
        public ICollection<Visit> PatientVisits { get; set; }
        public ICollection<Visit> DoctorVisits { get; set; }
    }
}
