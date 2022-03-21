using Layer.Architecture.Domain.Entities;
using Layer.Architecture.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Layer.Architecture.Service.Services
{
    public interface IUserService
    {
        User GetUserByLogin(string login, string password);
        bool Add(User user);
    }
}
