using System.Linq;
using AutoMapper;
using Data.Context;
using Data.Repository.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Service.Services
{
    public class UserService : BaseService<User>, IUserService

    {
        private readonly RaCaGakContext _raCaGaKContext;
        private readonly IUserRepository _userRepository;

        public UserService(RaCaGakContext raCaGakContext, IBaseRepository<User> baseRepository, IMapper mapper,
            IUserRepository userRepository) : base(baseRepository, mapper)
        {
            _userRepository = userRepository;
            _raCaGaKContext = raCaGakContext;
        }

        public bool Add(User user)
        {
            user.Passwd = BCrypt.Net.BCrypt.HashPassword(user.Passwd, BCrypt.Net.BCrypt.GenerateSalt());

            return _userRepository.CreateUser(user);
        }

        public User GetUserByLogin(string login, string password)
        {
            var account = _raCaGaKContext.Set<User>().ToList().FirstOrDefault(x => x.NickName == login);

            if (account == null)
                return null;

            var isVerified = _userRepository.GetAuthenticatedUser(account, login, password);

            return isVerified ? account : null;
        }
    }
}