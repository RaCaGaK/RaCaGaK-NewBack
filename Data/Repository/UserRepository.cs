using System.Linq;
using Data.Context;
using Data.Repository.Interfaces;
using Domain.Entities;


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
        public User GetUserByLogin(string login)
        {
            return _raCaGaKContext.Set<User>().ToList().FirstOrDefault(x => x.NickName == login || x.Email == login);
        }
    
    }
}