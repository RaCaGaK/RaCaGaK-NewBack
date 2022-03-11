using AutoMapper;
using Layer.Architecture.Domain.Entities;
using Layer.Architecture.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Layer.Architecture.Service.Services
{
    public class UserService : BaseService<User>
    {
        public UserService(IBaseRepository<User> baseRepository, IMapper mapper) : base(baseRepository, mapper)
        {
        }

        public User GetUserTeste(int id)
        {
            return GetById<User>(id);
        }
    }
}
