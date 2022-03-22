using Domain.Entities;

namespace Data.Repository.Interfaces
{
    public interface IUserRepository
    {
        bool GetAuthenticatedUser(User user, string login, string password);
        User GetUserById(int id);
        bool CreateUser(User user);
    }
}