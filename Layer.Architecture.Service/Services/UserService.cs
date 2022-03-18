using AutoMapper;
using Layer.Architecture.Domain.Entities;
using Layer.Architecture.Domain.Interfaces;
using Layer.Architecture.Infra.Data.Repository;
using Layer.Architecture.Infra.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Layer.Architecture.Service.Services
{
    public class UserService : BaseService<User>, IUserService

    {
        private readonly IUserRepository _userRepository;
        public UserService(IBaseRepository<User> baseRepository, IMapper mapper, IUserRepository userRepository ) : base(baseRepository, mapper)
        {
            _userRepository = userRepository;
        }
        

 

        public IEnumerable<User> GetUserByLogin(string login, string password)
        {
            return _userRepository.GetAuthenticatedUser(login, password);
        }
    }
}
