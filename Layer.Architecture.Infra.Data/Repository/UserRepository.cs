using Layer.Architecture.Domain.Entities;
using Layer.Architecture.Domain.Models;
using Layer.Architecture.Infra.Data.Context;
using Layer.Architecture.Infra.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BC = BCrypt.Net.BCrypt;

namespace Layer.Architecture.Infra.Data.Repository
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
            return _raCaGaKContext.Set<User>().Where(x => x.Id == id).FirstOrDefault();
        }

        public bool CreateUser(User user)
        {
            _raCaGaKContext.Add(user);
            _raCaGaKContext.SaveChanges();

            return true;
        }

        public bool GetAuthenticatedUser(User user, string login, string password)
        {
            if (user == null || !BC.Verify(password, user.Passwd))
            {
                return false;
            }

            return true;
        }
    }
}
