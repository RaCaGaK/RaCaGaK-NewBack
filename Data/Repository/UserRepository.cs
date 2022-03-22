using System.Linq;
using Data.Context;
using Data.Repository.Interfaces;
using Domain.Entities;
using BC = BCrypt.Net.BCrypt;

namespace Data.Repository
{
    public class UserRepository : IUserRepository
    {
        protected readonly RaCaGakContext _raCaGaKContext;

        public UserRepository(RaCaGakContext raCaGaKContext)
        {
            _raCaGaKContext = raCaGaKContext;
        }

        public User GetUserById(int id)
        {
            return _raCaGaKContext.Set<User>().FirstOrDefault(x => x.Id == id);
        }

        public bool CreateUser(User user)
        {
            _raCaGaKContext.Add(user);
            _raCaGaKContext.SaveChanges();

            return true;
        }

        public bool GetAuthenticatedUser(User user, string login, string password)
        {
            return user != null && BC.Verify(password, user.Passwd);
        }
    }
}