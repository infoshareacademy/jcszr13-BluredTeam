using PP0.WEB.Models;
using PP0.WEB.Models.Enums;

namespace PP0.WEB.Services
{
    public class VisitService
    {
        private static int _idCounter = 2;
        private static List<Visit> _visits = new List<Visit>
        {
            new Visit()
            {
                Id = 1,
                Date = new DateTime(2020,1,5),
                Type = VisitType.Stationary,
                DoctorName = "Jan Kowalski",
                PatientName = "Anna Nowak",
                Description = "Opis wizyty",
                Recomendations = "Rekomendacje",
                Referrals = "Skierowania brak",
                Prescriptions = "Recepta brak"
            },
            new Visit()
            {
                Id = 2,
                Date = new DateTime(2022,3,4),
                Type = VisitType.Chat,
                DoctorName = "Pior Zieliński",
                PatientName = "Maria Szpak",
                Description = "Opis wizyty dwa",
                Recomendations = "Rekomendacje dwa",
                Referrals = "Skierowania brak",
                Prescriptions = "Recepta brak"
            }

         };
        public List<Visit> GetAll()
        {
            return _visits;
        }

        public Visit GetById(int id)
        {
            return _visits.FirstOrDefault(x => x.Id == id);
        }
        public void Create(Visit visit)
        {
            visit.Id = GetNextId();
            _visits.Add(visit);
        }
        public void Update(Visit model)
        {
            var visit = GetById(model.Id);
            visit.Recomendations = model.Recomendations;
            visit.Description = model.Description;
            visit.Date = model.Date;
            visit.Type = model.Type;
            visit.Prescriptions = model.Prescriptions;
            visit.DoctorName = model.DoctorName;
            visit.PatientName = model.PatientName;
            visit.Referrals = model.Referrals;
        }

        public void Delete(int id)
        {
            var visit = GetById(id);
            _visits.Remove(visit);
        }
        private int GetNextId()
        {
            _idCounter++;

            return _idCounter;
        }
    }
}
