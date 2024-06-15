using PP0.WEB.Interfaces;
using PP0.WEB.Models;

namespace PP0.WEB.Services
{

    public class UserService :IUserService
    {
        private  List<User> _users ;
        public List<User> GetAllItems() 
        { 
             _users = JsonService.DeserilizeJson<User>(@"Files\UsersDb.json");
            return _users;
        }
    }
}
