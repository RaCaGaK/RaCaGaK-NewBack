using Domain.Entities;

namespace Data.Repository.Interfaces
{
    public interface IUserRepository
    {
        User GetUserById(int id);
        bool CreateUser(User user);

        User GetUserByLogin(string login);
    }
}