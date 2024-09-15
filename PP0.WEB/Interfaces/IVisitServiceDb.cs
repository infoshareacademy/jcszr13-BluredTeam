using PP0.EntityFrameworkCore.Database.Entities;

namespace PP0.WEB.Interfaces
{
    public interface IVisitServiceDb
    {
        List<Visit> GetAllVisits();
    }
}
