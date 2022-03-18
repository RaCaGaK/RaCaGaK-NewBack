using Layer.Architecture.Domain.Entities;
using Layer.Architecture.Infra.Data.Context;
using Layer.Architecture.Infra.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Layer.Architecture.Infra.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        protected readonly RaCaGakContext _raCaGaKContext;

        public UserRepository(RaCaGakContext raCaGaKContext)
        {
            _raCaGaKContext = raCaGaKContext;
        }

        public IEnumerable<User> GetAuthenticatedUser(string login, string password)
        {
            var userAthenticated = _raCaGaKContext.Set<User>().ToList().Where(x => (x.NickName == login || x.Email == login) && x.Passwd == password);
            
            return userAthenticated;
        }
    }
}
