
using Microsoft.EntityFrameworkCore;
using PP0.EntityFrameworkCore.Database.Context;
using PP0.EntityFrameworkCore.Database.Entities;
using PP0.WEB.Interfaces;

namespace PP0.WEB.Services
{
    public class VisitServiceDb : IVisitServiceDb
    {
        private readonly PP0DatabaseContext _dbContext;
        public VisitServiceDb(PP0DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Visit visit)
        {
            _dbContext.Visits.Add(visit);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var exisitnigVisit = _dbContext.Visits.FirstOrDefault(x => x.Id == id);
            _dbContext.Remove(exisitnigVisit);
            _dbContext.SaveChanges();
        }

        public void Edit(int id, Visit visit)
        {
            var exisitnigVisit = _dbContext.Visits.FirstOrDefault(x => x.Id == id);
            exisitnigVisit.PatientId = visit.PatientId;
            exisitnigVisit.DoctorId = visit.DoctorId;
            exisitnigVisit.Type = visit.Type;
            exisitnigVisit.Date = visit.Date;
            exisitnigVisit.Prescriptions = visit.Prescriptions;
            exisitnigVisit.Recomendations = visit.Recomendations;
            exisitnigVisit.Referrals = visit.Referrals;
            exisitnigVisit.Description = visit.Description;

            _dbContext.SaveChanges();
        }

        public List<Visit> GetAllVisits()
        {
            return _dbContext.Visits.Include(x => x.Patient).Include(x => x.Doctor).ToList();
        }

        public Visit GetById(int id)
        {
            return _dbContext.Visits.Include(x=>x.Patient).Include(x => x.Doctor).FirstOrDefault(x=>x.Id == id);
        }
    }
}
