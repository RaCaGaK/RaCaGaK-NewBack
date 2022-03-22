using Domain.Entities;

namespace Service.Services
{
    public interface IUserService
    {
        User GetUserByLogin(string login, string password);
        bool Add(User user);
    }
}