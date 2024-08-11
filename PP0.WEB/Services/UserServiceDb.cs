using PP0.EntityFrameworkCore.Database.Context;
using PP0.EntityFrameworkCore.Database.Entities;
using PP0.WEB.Interfaces;

namespace PP0.WEB.Services
{
    public class UserServiceDb : IUserServiceDb
    {
        private readonly PP0DatabaseContext _dbContext;
        public UserServiceDb( PP0DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
    
        public List<User> GetAllUsers()
        {
           return  _dbContext.AppUsers.ToList();
        }
    }
}
