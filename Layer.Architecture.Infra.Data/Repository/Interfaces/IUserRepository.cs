using Layer.Architecture.Domain.Entities;
using Layer.Architecture.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Layer.Architecture.Infra.Data.Repository.Interfaces
{
    public interface IUserRepository
    {
        bool GetAuthenticatedUser(User user, string login, string password);
        User GetUserById(int id);
        bool CreateUser(User user);
    }
}
