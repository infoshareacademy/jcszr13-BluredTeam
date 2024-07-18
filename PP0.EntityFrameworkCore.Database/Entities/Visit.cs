using PP0.EntityFrameworkCore.Database.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace PP0.EntityFrameworkCore.Database.Entities
{
    public class Visit
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public VisitType Type { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public string Description { get; set; }
        public string Recomendations { get; set; }
        public string Referrals { get; set; }
        public string Prescriptions { get; set; }

        public User Doctor { get; set; }
        public User Patient { get; set; }

        public Visit()
        {

        }        
    }
}

