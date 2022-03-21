using AutoMapper;
using Layer.Architecture.Domain.Entities;
using Layer.Architecture.Domain.Interfaces;
using Layer.Architecture.Domain.Models;
using Layer.Architecture.Infra.Data.Context;
using Layer.Architecture.Infra.Data.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Layer.Architecture.Service.Services
{
    public class UserService : BaseService<User>, IUserService

    {
        private readonly IUserRepository _userRepository;
        private readonly RaCaGakContext _raCaGaKContext;
        public UserService(RaCaGakContext raCaGakContext, IBaseRepository<User> baseRepository, IMapper mapper, IUserRepository userRepository ) : base(baseRepository, mapper)
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
            var account = _raCaGaKContext.Set<User>().ToList().Where(x => x.NickName == login).FirstOrDefault();

            if (account == null)
                return null;

            var isVerified = _userRepository.GetAuthenticatedUser(account, login, password);

            return isVerified ? account : null;
        }
    }
}
