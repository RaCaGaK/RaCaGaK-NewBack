using Layer.Architecture.Domain.Entities;
using Layer.Architecture.Infra.Data.Builder;
using Layer.Architecture.Infra.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Layer.Architecture.Infra.Data.Builder
{
    public class UserBuilder : IUserBuilder
    {
        private readonly IUserRepository _userRepository;

        public UserBuilder (IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool Build(UserBuilderCommand command)
        {
            var userExiste = _userRepository.GetUserById(command.Id);

            if (userExiste == null)
            {
                return false;
            }

            var pass = BCrypt.Net.BCrypt.HashPassword(command.Passwd, BCrypt.Net.BCrypt.GenerateSalt());

            var user = new User(command.FullName, command.NickName, command.Email, command.ImgUrl, pass);


            return true;
        }
    }
}
