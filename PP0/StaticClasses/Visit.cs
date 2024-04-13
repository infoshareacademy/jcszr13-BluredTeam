using PP0.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP0.StaticClasses
{
    internal class Visit
    {
        public DateTime Date {  get; set; }
        public VisitType Type { get; set; }
        public string DoctorName { get; set; }
        public string PatientName { get; set; }
        public string Description { get; set;}
        public string Recomendations { get; set; }
        public string Referrals {  get; set; }
        public string Prescriptions { get; set; }

        public Visit(DateTime date, VisitType type, string doctorName, string patientName, string description, string recomendations, string referrals, string prescriptions)
        {
            Date = date;
            Type = type;
            DoctorName = doctorName;
            PatientName = patientName;
            Description = description;
            Recomendations = recomendations;
            Referrals = referrals;
            Prescriptions = prescriptions;
        }
    }


}

