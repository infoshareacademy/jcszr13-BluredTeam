using PP0.WEB.Interfaces;

namespace PP0.WEB.Services
{
    public interface ILoginService
    {
         void LoginUser(string username, string password);
    }
    public class LoginService : ILoginService
    {
        public void LoginUser(string user, string password) 
        { }
        public LoginService(IUserService userService)
        {
            
        }
    }
}
