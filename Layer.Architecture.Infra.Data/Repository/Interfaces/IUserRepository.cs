using Layer.Architecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Layer.Architecture.Infra.Data.Repository.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAuthenticatedUser(string login, string password);
    }
}
