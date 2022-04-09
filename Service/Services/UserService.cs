using System.Linq;
using AutoMapper;
using Data.Context;
using Data.Repository.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using BC = BCrypt.Net.BCrypt;

namespace Service.Services
{
    public class UserService : BaseService<User>, IUserService

    {
        private readonly IUserRepository _userRepository;

        public UserService(IBaseRepository<User> baseRepository, IMapper mapper,
            IUserRepository userRepository) : base(baseRepository, mapper)
        {
            _userRepository = userRepository;
        }

        public bool Add(User user)
        {
            user.Passwd = BC.HashPassword(user.Passwd, BCrypt.Net.BCrypt.GenerateSalt());

            return _userRepository.CreateUser(user);
        }

        public User GetUserByLogin(string login, string password)
        {
            var account = _userRepository.GetUserByLogin(login);

            if (account == null)
                return null;

            var isVerified =  BC.Verify(password, account.Passwd);

            return isVerified ? account : null;
        }
    }
}