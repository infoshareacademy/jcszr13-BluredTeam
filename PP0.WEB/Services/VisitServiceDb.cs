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
        public List<Visit> GetAllVisits() 
        {
            return _dbContext.Visits.Include( x => x.Doctor).Include(x => x.Patient).ToList();
        }
    }
}
