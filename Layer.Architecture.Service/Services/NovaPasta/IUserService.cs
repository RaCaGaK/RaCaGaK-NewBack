using Layer.Architecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Layer.Architecture.Service.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetUserByLogin(string login, string password);
    }
}
