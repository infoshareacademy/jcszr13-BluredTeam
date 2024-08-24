
using PP0.EntityFrameworkCore.Database.Entities;

namespace PP0.WEB.Interfaces
{
    public interface IVisitServiceDb
    {
        List<Visit> GetAllVisits();
        Visit GetById(int id);
        void Create(Visit visit);
        void Edit(int id, Visit visit);
        void Delete(int id);
    }
}
