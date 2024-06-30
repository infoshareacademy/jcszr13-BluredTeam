using PP0.WEB.Models;

namespace PP0.WEB.Interfaces
{
    public interface IUserService
    {
        public List<User> GetAllItems();

        public int GetUserNextId();

        public void Create(User user);
    }
}
